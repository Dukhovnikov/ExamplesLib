using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib.WebRequest.Tests
{
    public class WebRequestSender
    {
        public static void SimpleSend()
        {
            var data = $"id=666&phone=7666&result=666&control=666&cmd=status";
            var url = "http://localhost:54624";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(url, data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SimpleSendWithUriBuilder()
        {
            var data = $"id=666&phone=7666&result=666&control=666&cmd=status";
            var url = "http://localhost:54624";

            try
            {
                using (WebClient client = new WebClient())
                {
                    UriBuilder uri = new UriBuilder(url)
                    {
                        Query = data
                    };

                    string result = client.DownloadString(uri.Uri);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


