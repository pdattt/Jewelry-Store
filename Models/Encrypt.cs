using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Project.Models
{
    public class Encrypt
    {
        public static string Key = "1975";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDencrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData))
                return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);

            //Tách chuỗi key đang chứa trong chuỗi password đã giải mã
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}