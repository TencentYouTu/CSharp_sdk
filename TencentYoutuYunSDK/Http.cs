using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TencentYoutuYun.SDK.Csharp
{
    public class Http
    {
        /// <summary>
        /// send http request with POST method
        /// </summary>
        /// <param name="postUrl">请求的url地址</param>
        /// <param name="postData">请求数据</param>
        /// <param name="authorization">签名</param>
        /// <returns></returns>
        public static string Post(string postUrl, string postData, string authorization)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "text/json";
                webReq.Headers.Add(HttpRequestHeader.Authorization, authorization);
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        int errorcode = (int)response.StatusCode;
                        ret = Youtu.statusText(errorcode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
            return ret;
        }
    }
}
