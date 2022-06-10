using System.Security.Cryptography;

namespace AVS.Core.Utils
{
    public class SegurancaUtil
    {
        public static String HashSHA1(String plainText)
        {
            return GetSHA1HashData(plainText);
        }

        private static string GetSHA1HashData(string data)
        {
            var SHA1 = new SHA1CryptoServiceProvider();
            byte[] byteV = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteH = SHA1.ComputeHash(byteV);

            SHA1.Clear();

            return Convert.ToBase64String(byteH);
        }
    }
}
