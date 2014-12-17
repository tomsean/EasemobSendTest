using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class HttpUtil
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HttpUtil));
        public T HttpGet<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return HttpRequest<T>(url, "Get", bodyData, headers);
        }

        public Task<T> HttpGetAsync<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return Task.Run(() =>
            {
                var result = HttpGet<T>(url, bodyData, headers);
                return result;
            });
        }

        public T HttpPost<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            if (!headers.Keys.Any(e => e.ToLower().Equals("content-type")))
            {
                headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            return HttpRequest<T>(url, "Post", bodyData, headers);
        }

        public Task<T> HttpPostAsync<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return Task.Run(() =>
            {
                var result = HttpPost<T>(url, bodyData, headers);
                return result;
            });
        }

        public T HttpPut<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            if (!headers.Keys.Any(e => e.ToLower().Equals("contenttype")))
            {
                headers.Add("Content-Type", "application/x-www-form-urlencoded");
            }
            return HttpRequest<T>(url, "Put", bodyData, headers);
        }

        public Task<T> HttpPutAsync<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return Task.Run(() =>
            {
                var result = HttpPut<T>(url, bodyData, headers);
                return result;
            });
        }

        public T HttpDelete<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return HttpRequest<T>(url, "Delete", bodyData, headers);
        }

        public Task<T> HttpDeleteAsync<T>(string url, string bodyData, Dictionary<string, string> headers = null)
        {
            return Task.Run(() =>
            {
                var result = HttpDelete<T>(url, bodyData, headers);
                return result;
            });
        }

        private static T HttpRequest<T>(string url, string method, string bodyData, Dictionary<string, string> headers)
        {
            try
            {
                var hwr = WebRequest.Create(url) as HttpWebRequest;
                if (hwr == null) return default(T);
                hwr.Method = method;
                if (headers != null)
                {
                    hwr.Headers = new WebHeaderCollection();
                    foreach (var header in headers)
                    {
                        if (header.Key.ToLower() != "content-type")
                        {
                            hwr.Headers.Add(header.Key, header.Value);
                        }
                        else
                        {
                            hwr.ContentType = header.Value;
                        }
                    }
                }
                var postdata = bodyData;
                if (!string.IsNullOrEmpty(postdata))
                {
                    var data = Encoding.UTF8.GetBytes(postdata);
                    using (var stream = hwr.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                var response = hwr.GetResponse() as HttpWebResponse;
                if (response == null) return default(T);
                var responseStream = response.GetResponseStream();
                var resultStr = string.Empty;
                if (responseStream != null)
                {
                    var reader = new StreamReader(responseStream);
                    resultStr = reader.ReadToEnd();
                }
                return !string.IsNullOrEmpty(resultStr) ? JsonConvert.DeserializeObject<T>(resultStr) : default(T);
            }
            catch (Exception ex)
            {
                Logger.Error("http 异常" + ex.Message);
                throw;
            }
        }
    }
}