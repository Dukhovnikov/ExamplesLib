using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace CommonData.ClassLib.Utils
{
    /// <summary>Вспомагательные методы для работы с HttpContext</summary>
    public static class WebUtils
    {
        public static string GetClientIP(this HttpContext context)
        {
            string ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        private static void Measure(string name, Func<long> callback)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var mem = GC.GetTotalMemory(true);
            var gc00 = GC.CollectionCount(0);
            var gc01 = GC.CollectionCount(1);
            var gc02 = GC.CollectionCount(2);

            var sw = Stopwatch.StartNew();
            var result = callback();
            sw.Stop();

            var mem2 = GC.GetTotalMemory(false);
            var gc10 = GC.CollectionCount(0);
            var gc11 = GC.CollectionCount(1);
            var gc12 = GC.CollectionCount(2);

            var memDelta = (mem2 - mem) / 1024.0;
            var gcDelta0 = gc10 - gc00;
            var gcDelta1 = gc11 - gc01;
            var gcDelta2 = gc12 - gc02;

            Console.WriteLine(
                "{0,20}: {1,5}ms, ips: {2,22:N} | Mem: {3,9:N2} kb, GC 0/1/2: {4}/{5}/{6} => {7,6}",
                name, sw.ElapsedMilliseconds, result / sw.Elapsed.TotalSeconds, memDelta, gcDelta0, gcDelta1, gcDelta2, result);
        }

        public static bool IsBasicAuthenticated(string basicHeader, string name, string password)
        {
            string credential = GetBasicAuthenticationParameters(name, password);
            return basicHeader == $"Basic {credential}";
        }

        public static string GetBasicAuthHeader(string name, string password) => $"Basic {GetBasicAuthenticationParameters(name, password)}";

        public static string GetBasicAuthenticationParameters(string name, string password) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{name}:{password}"));

        public static X509Certificate2 GetClientCertificate(this HttpContext context)
        {
            if (context.Request.ClientCertificate != null
                && context.Request.ClientCertificate.Certificate != null
                && context.Request.ClientCertificate.Certificate.Length > 0)
            {
                return new X509Certificate2(context.Request.ClientCertificate.Certificate);
            }
            else if (!string.IsNullOrEmpty(context.Request.Headers["X-ARR-ClientCert"]))
            {
                string base64Certificate = context.Request.Headers["X-ARR-ClientCert"];

                return Base64ToCertificate(base64Certificate);
            }
            return null;
        }

        public static X509Certificate2 Base64ToCertificate(this string base64Certificate)
        {
            byte[] certificateData = Convert.FromBase64String(base64Certificate);

            return new X509Certificate2(certificateData);
        }

        private static void LogNameValueCollection(NameValueCollection collection, StringBuilder sb)
        {
            foreach (string key in collection.AllKeys)
            {
                sb.Append(key).Append("=").Append(collection[key]).AppendLine();
            }
        }

        private static string GetRequestContentString(HttpRequest request)
        {
            var stream = request.InputStream;
            long position = stream.Position;
            try
            {
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, (int)stream.Length);
                var result = request.ContentEncoding.GetString(data);

                var header = request.Headers.NameValueCollectionToPlainString();

                return $"url : {request.Url}{Environment.NewLine}headers:{Environment.NewLine}{header}{Environment.NewLine}data:{Environment.NewLine}{result}";
            }
            finally
            {
                stream.Position = position;
            }
        }

        public static NameValueCollection ToNameValueCollection(this string data)
        {
            NameValueCollection result = new NameValueCollection();

            string[] parts = data.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string pair in parts)
            {
                string[] kp = pair.Split('=');
                result[WebUtility.UrlDecode(kp[0])] = kp.Length > 1 ? WebUtility.UrlDecode(kp[1]) : null;
            }

            return result;
        }

        public static string ToQueryString(this NameValueCollection collection, string[] exceptFields = null)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var key in collection.AllKeys)
            {
                if (exceptFields?.Contains(key) == true) continue;
                builder.Append($"{ WebUtility.UrlEncode(key)}={WebUtility.UrlEncode(collection[key])}&");
            }

            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }

        public static string GetWebExceptionContext(WebException webException)
        {
            try
            {
                if (webException.Response != null)
                {
                    var responseStream = webException.Response.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new System.IO.StreamReader(responseStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                //Осознанно гасим исключение, поскольку логирование не должно влиять на логику выше
                return "Exception occured during reading webException content";
            }
            return string.Empty;
        }

        public static void WriteResponseAsJson(this HttpContext context, object response)
        {
            string result = JsonConvert.SerializeObject(response);
            context.Response.ContentEncoding = Encoding.UTF8;
            byte[] data = Encoding.UTF8.GetBytes(result);
            context.Response.OutputStream.Write(data, 0, data.Length);
        }


        public static string NameValueCollectionToPostForm(this NameValueCollection collection)
        {
            StringBuilder result = new StringBuilder();
            foreach (string key in collection.AllKeys)
            {
                result.Append(HttpUtility.UrlEncode(key)).Append('=').Append(HttpUtility.UrlEncode(collection[key])).Append("&");
            }
            if (result.Length > 0) { result.Remove(result.Length - 1, 1); }

            return result.ToString();
        }

        public static string NameValueCollectionToPlainString(this NameValueCollection collection)
        {
            StringBuilder result = new StringBuilder();
            foreach (string key in collection.AllKeys)
            {
                result.Append(key).Append('=').Append(collection[key]).Append("&");
            }

            if (result.Length > 0) { result.Remove(result.Length - 1, 1); };

            return result.ToString();
        }

        public static string ReadRawRequest(HttpRequest request, Encoding encoding)
        {
            var size = request.InputStream.Length;
            var data = new byte[size];
            request.InputStream.Read(data, 0, (int)size);
            return encoding.GetString(data);
        }
    }
}
