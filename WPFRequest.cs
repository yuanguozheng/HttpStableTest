using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace HttpStableTest
{
    public class WPFRequest
    {
        HttpWebRequest Request;
        HttpWebResponse Response;

        /// <summary>
        /// 结果状态，标识是否请求成功
        /// </summary>
        public bool ResultState { get; set; }

        /// <summary>
        /// 返回字符串
        /// </summary>
        public string ResponseString { get; set; }

        /// <summary>
        /// 构造函数，指定URL和请求方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Method"></param>
        public WPFRequest(string Url, string Method = "GET", int OutOfTime = 30)
        {
            try
            {
                Request = (HttpWebRequest)HttpWebRequest.Create(Url);
                Request.Timeout = OutOfTime;
            }
            catch
            {
                ResultState = false;
                return;
            }
            if (Method.ToUpper() != "GET" && Method.ToUpper() != "POST")
            {
                Request.Method = "GET";
            }
            else
            {
                Request.Method = Method;
                if (Method.ToUpper() == "POST")
                {
                    Request.ContentType = "application/x-www-form-urlencoded";
                }
            }
            Request.UserAgent = "HTTP_Stable_Tester";
        }

        /// <summary>
        /// 添加POST参数字符串
        /// </summary>
        /// <param name="ParamString">参数字符串</param>
        /// <returns>true:添加成功，false:添加失败</returns>
        public bool PostParams(string ParamString)
        {
            if (Request.Method.ToUpper() == "POST")
            {
                using (Stream ParamStream = Request.GetRequestStream())
                {
                    byte[] PostBin = Encoding.UTF8.GetBytes(ParamString);
                    if (PostBin.Length == 0)
                    {
                        return false;
                    }
                    ParamStream.Write(PostBin,0,PostBin.Length);
                }
            }
            return true;
        }

        /// <summary>
        /// 进行请求
        /// </summary>
        public void DoRequest()
        {
            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
            }
            catch
            {
                ResultState = false;
                return;
            }
            using (Stream ResponseStream = Response.GetResponseStream())
            {
                StreamReader Reader = new StreamReader(ResponseStream, Encoding.Default);
                ResponseString = Reader.ReadToEnd();
            }
            ResultState = true;
        }
    }
}
