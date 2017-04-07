using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mylibrary
{
    public static class EncHelper
    {
        public static string MD5Encrypt32(string password)
        {
            byte[] result = Encoding.Default.GetBytes(password.Trim());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");         
        }


    }
}
