using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.ClassLib.Utils
{
    /// <summary>Вспомогательные методы для работы с сертификатами</summary>
    public static class CertUtils
    {
        public static X509Certificate2 FindCertificateByName(string name)
        {
            Func<X509Certificate2, bool> condition = c =>
            {
                return c.GetNameInfo(X509NameType.SimpleName, false) == name;
            };
            X509Certificate2 result = FindCertificates(name, X509FindType.FindBySubjectName, StoreName.My, condition).FirstOrDefault();

            return result ?? FindCertificates(name, X509FindType.FindBySubjectName, StoreName.Root, condition).FirstOrDefault();
        }

        internal static IEnumerable<X509Certificate2> FindCertificatesByName(string name)
        {
            Func<X509Certificate2, bool> condition = c =>
            {
                return c.GetNameInfo(X509NameType.SimpleName, false) == name;
            };

            List<X509Certificate2> result = new List<X509Certificate2>(10);
            result.AddRange(FindCertificates(name, X509FindType.FindBySubjectName, StoreName.My, condition));
            result.AddRange(FindCertificates(name, X509FindType.FindBySubjectName, StoreName.Root, condition));

            return result;
        }

        public static X509Certificate2 FindCertificateBySubjectDistinguishedName(string name)
        {
            X509Certificate2 result = FindCertificates(name, X509FindType.FindBySubjectDistinguishedName, StoreName.My).FirstOrDefault();
            return result ?? FindCertificates(name, X509FindType.FindBySubjectDistinguishedName, StoreName.Root).FirstOrDefault();
        }

        public static IEnumerable<X509Certificate2> FindCertificates(string name, X509FindType findType, StoreName store, Func<X509Certificate2, bool> certificateCondition = null)
        {
            var certStore = new X509Store(store, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.MaxAllowed);
            try
            {
                var certs = certStore.Certificates.Find(findType, name, false).Cast<X509Certificate2>();
                if (certificateCondition != null)
                {
                    certs = certs.Where(certificateCondition);
                }

                return certs;
            }
            finally
            {
                certStore.Close();
            }
        }

        public static byte[] SignBySHA1Hash(byte[] data, X509Certificate2 certificate)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PrivateKey;
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return csp.SignData(data, sha1);
            }
        }

        public static byte[] SignByMD5Hash(byte[] data, X509Certificate2 certificate)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PrivateKey;
            return csp.SignData(data, "MD5");
        }

        public static bool MD5VerifySignature(byte[] data, byte[] signature, X509Certificate2 certificate)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            return csp.VerifyData(data, "MD5", signature);
        }

        public static bool MD5VerifySignatureByPEM(string data, RSAParameters publicKey, byte[] signature, Encoding encoding)
        {
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.ImportParameters(publicKey);
                return csp.VerifyData(encoding.GetBytes(data), "MD5", signature);
            }
        }

        public static bool SHA1VerifySignatureByPEM(string data, RSAParameters publicKey, byte[] signature, Encoding encoding)
        {
            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                csp.ImportParameters(publicKey);
                return csp.VerifyData(encoding.GetBytes(data), CryptoConfig.MapNameToOID("SHA1"), signature);
            }
        }

        public static bool SHA1VerifySignature(byte[] data, byte[] signature, X509Certificate2 certificate)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(data);
                return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
            }
        }

        public static string ComputeSha1(this string stringToHash)
        {
            var data = Encoding.UTF8.GetBytes(stringToHash);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(data)).Replace("-", "");
            }
        }

        public static byte[] ComputeHmacSha1(this string toHash, byte[] key)
        {
            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(toHash));
            }
        }

        public static string ComputeMd5(this string stringToHash)
        {
            var data = Encoding.UTF8.GetBytes(stringToHash);
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(data)).Replace("-", "");
            }
        }

        public static string ComputeSha256(this string stringToHash)
        {
            var data = Encoding.UTF8.GetBytes(stringToHash);
            using (SHA256Managed sha = new SHA256Managed())
            {
                return BitConverter.ToString(sha.ComputeHash(data)).Replace("-", "");
            }
        }

    }
}
