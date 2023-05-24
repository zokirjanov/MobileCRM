using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCRM
{
    internal class GlobalConstants
    {
        public static string CalculateMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 alg = System.Security.Cryptography.MD5.Create();
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();

            byte[] hash = alg.ComputeHash(enc.GetBytes(input));
            string output = Convert.ToBase64String(hash);
            return output;
        }
    }
}
