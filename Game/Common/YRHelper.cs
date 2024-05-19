using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game.Common
{
    public class YRHelper
    {
        public static string GetClientIPAddress(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                ip = context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
            }
            return ip;
        }

        #region MD5加密解密
        /// <summary>
        /// MD5(16位加密)
        /// </summary>
        /// <param name="ConvertString">需要加密的字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        public static string get_md5_16(string ConvertString)
        {
            string md5Pwd = string.Empty;

            //使用加密服务提供程序
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //将指定的字节子数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
            md5Pwd = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);

            md5Pwd = md5Pwd.Replace("-", "");

            return md5Pwd.ToLower();
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string get_md5_32(string ConvertString)
        {
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(ConvertString);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes, 0, bytes.Length);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer2)
            {
                builder.Append(num.ToString("x2"));
            }
            return builder.ToString();
        }
        #endregion

        /// <summary>
        /// url编码和解码
        /// </summary>
        /// <param name="flag">true编码，false解码</param>
        /// <param name="content">内容</param>
        /// <returns>返回url编码/解码后的值</returns>
        public static string url_en_de_code(bool flag, string content)
        {
            var value = string.Empty;
            if (flag)
            {
                value = System.Web.HttpUtility.UrlEncode(content, System.Text.Encoding.UTF8);　　　　//UrlEncode编码
            }
            else
            {
                value = System.Web.HttpUtility.UrlDecode(content, System.Text.Encoding.UTF8);　　　　　//UrlDecode解码
            }
            return value;
        }


        #region AES加密解密 
        //密钥
        public static string key = "b7hy1pwtj8ar3ge5";

        //加密初始化向量
        public static string iv = "k4ev5kcnal94h3hm";

        //密钥
        public static string openidkey = "b7hy1pwtj8ar3ge5";

        //加密初始化向量
        public static string openidiv = "k4ev5kcnal94h3hm";

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="obj">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string OpenIdEncrypt(object obj)
        {
            string rer = "";

            string str = JsonConvert.SerializeObject(obj);

                Byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(openidkey);
                Byte[] toEncryptArray = System.Text.Encoding.UTF8.GetBytes(str);
                var rijndael = new System.Security.Cryptography.RijndaelManaged();
                rijndael.Key = keyArray;
                rijndael.Mode = System.Security.Cryptography.CipherMode.ECB;
                rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                rijndael.IV = System.Text.Encoding.UTF8.GetBytes(openidiv);
                System.Security.Cryptography.ICryptoTransform cTransform = rijndael.CreateEncryptor();
                Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                rer = Convert.ToBase64String(resultArray, 0, resultArray.Length);

            return rer;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string OpenIdDecrypt(string str)
        {
            Byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(openidkey);
            Byte[] toEncryptArray = Convert.FromBase64String(str);
            var rijndael = new System.Security.Cryptography.RijndaelManaged();
            rijndael.Key = keyArray;
            rijndael.Mode = System.Security.Cryptography.CipherMode.ECB;
            rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            rijndael.IV = System.Text.Encoding.UTF8.GetBytes(openidiv);
            System.Security.Cryptography.ICryptoTransform cTransform = rijndael.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            string jsonStr = System.Text.Encoding.UTF8.GetString(resultArray);

            ////针对转义字符特殊处理
            string resp = "";
            JsonReader readerJson = new JsonTextReader(new StringReader(jsonStr));
            while (readerJson.Read())
            {
                resp = readerJson.Value.ToString();
            }
            readerJson.Close();

            return resp;
        }
        #endregion

        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public static string GetRandom(int Length)
        {
            string result = "";
            char[] Pattern = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
    }
}
