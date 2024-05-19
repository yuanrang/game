using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Game.Common
{
    /// <summary>
    /// 请求信息帮助
    /// </summary>
    public class HttpHelper
    {
        private static HttpHelper m_Helper;
        /// <summary>
        /// 单例
        /// </summary>
        public static HttpHelper Helper
        {
            get { return m_Helper ?? (m_Helper = new HttpHelper()); }
        }

        #region Json

        public string GetMoths(string url)
        {
            string StrDate = "";
            string strValue = "";
            try
            {
                string strURL = url;
                System.Net.HttpWebRequest request;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36");
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.Stream s;
                s = response.GetResponseStream();

                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate + "\r\n";
                }
            }
            catch { }
            return strValue;
        }

        public string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.54 Safari/537.36");
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }

        /// <summary>
        /// 获取请求的数据
        /// </summary>
        /// <param name="strUrl">请求地址</param>
        /// <param name="jsonParameters">json参数</param>
        /// <param name="token">令牌</param>
        /// <returns>返回：请求成功响应信息，失败返回null</returns>
        public string GetResponseString(string strUrl, string jsonParameters, string token = "")
        {
            string url = VerifyUrl(strUrl);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse webResponse = PostRequest(webRequest, jsonParameters, token);

            if (webResponse != null && webResponse.StatusCode == HttpStatusCode.OK)
            {
                using (Stream newStream = webResponse.GetResponseStream())
                {
                    if (newStream != null)
                    {
                        using (StreamReader reader = new StreamReader(newStream))
                        {
                            string result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// post 请求指定地址返回响应数据
        /// </summary>
        /// <param name="webRequest">请求</param>
        /// <param name="requestBody">传入参数</param>
        /// <param name="token">token</param>
        /// <returns>返回：响应信息</returns>
        private HttpWebResponse PostRequest(HttpWebRequest webRequest, string requestBody, string token = "")
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = byteArray.Length;
            webRequest.Method = "POST";
            webRequest.ProtocolVersion = HttpVersion.Version10;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (!string.IsNullOrEmpty(token))
            {
                webRequest.Headers.Add("Authorization", "Bearer " + token);
            }

            // 将参数写入流
            using (Stream newStream = webRequest.GetRequestStream())
            {
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }

            // 接收返回信息
            return (HttpWebResponse)webRequest.GetResponse();
        }
        #endregion

        #region form-data
        /// <summary>
        /// 获取请求的数据
        /// </summary>
        /// <param name="strUrl">地址</param>
        /// <param name="formItems">文件</param>
        /// <param name="dic">键值对</param>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        public string GetResponseString(string strUrl, List<FormItemModel> formItems, Dictionary<string, string> dics, string token = "")
        {
            string url = VerifyUrl(strUrl);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse webResponse = PostForm(webRequest, formItems, dics, token);

            if (webResponse != null && webResponse.StatusCode == HttpStatusCode.OK)
            {
                using (Stream newStream = webResponse.GetResponseStream())
                {
                    if (newStream != null)
                    {
                        using (StreamReader reader = new StreamReader(newStream))
                        {
                            string result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="formItems">文件</param>
        /// <param name="dic">键值对</param>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        private HttpWebResponse PostForm(HttpWebRequest request, List<FormItemModel> formItems, Dictionary<string, string> dics, string token = "")
        {
            #region 初始化请求对象
            request.Method = "POST";
            request.Timeout = 20000; // 默认20秒
            request.KeepAlive = true;

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            #endregion

            // 令牌
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "Bearer " + token);
            }

            //请求流
            var postStream = new MemoryStream();
            #region 处理键值对
            string keyFormdataTemplate =
                "\r\n--" + boundary +
                "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                "\r\n\r\n{1}";
            foreach (var dic in dics)
            {
                string formdata = string.Format(
                        keyFormdataTemplate,
                        dic.Key,
                        dic.Value);
                byte[] formdataBytes = null;
                if (postStream.Length == 0)
                    formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                else
                    formdataBytes = Encoding.UTF8.GetBytes(formdata);
                postStream.Write(formdataBytes, 0, formdataBytes.Length);
            }
            #endregion

            #region 处理Form表单请求内容
            string fileFormdataTemplate =
                "\r\n--" + boundary +
                "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                "\r\nContent-Type: application/octet-stream" +
                "\r\n\r\n";
            foreach (var item in formItems)
            {
                string formdata = string.Format(
                        fileFormdataTemplate,
                        item.Key,
                        item.FileName);
                byte[] formdataBytes = Encoding.UTF8.GetBytes(formdata);
                postStream.Write(formdataBytes, 0, formdataBytes.Length);

                //写入文件内容
                if (item.FileContent == null || item.FileContent.Length == 0)
                {
                    throw new Exception("上传文件时 FileContent 属性值不能为空");
                }
                else
                {
                    using (var stream = item.FileContent)
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            postStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            //结尾
            var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            postStream.Write(footer, 0, footer.Length);
            #endregion

            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流
                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                    postStream.Close();//关闭文件访问
                }
            }
            #endregion

            return (HttpWebResponse)request.GetResponse();
        }
        #endregion

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="url">待验证 URL</param>
        /// <returns></returns>
        private string VerifyUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL 地址不可以为空！");

            if (url.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || url.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
                return url;

            return string.Format("http://{0}", url);
        }
    }

    /// <summary>
    /// 表单数据项
    /// </summary>
    public class FormItemModel
    {
        /// <summary>
        /// 表单键
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 上传的文件名
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 上传的文件内容
        /// </summary>
        public Stream FileContent { set; get; }
    }
}
