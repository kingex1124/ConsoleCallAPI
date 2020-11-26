using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleCallAPI
{
    public class CallAPIHelper
    {
        public CallAPIHelper()
        {

        }

        #region 使用HttpClientCall API

        #region Post

          #region 方法一 用Dictionary

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 回傳Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public T CallAPIPost<T>(string url,Dictionary<string,string> postData)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIPost(url,postData));
        }

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public XmlDocument CallAPIPostXml (string url, Dictionary<string, string> postData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIPost(url, postData));

            return doc;
        }

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string CallAPIPost(string url, Dictionary<string, string> postData)
        {
            string result = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(postData);

                //異步Post
                var response = client.PostAsync(url, content).Result;

                //確保Http響應成功
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result.ToString();
            }

            return result;
        }

        #endregion

          #region 方法二 用string

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 參數傳入字串
        /// 回傳Json or Xml字串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public T CallAPIPost<T>(string url, string postData)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIPost(url, postData));
        }

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public XmlDocument CallAPIPostXml(string url, string postData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIPost(url, postData));

            return doc;
        }

        /// <summary>
        /// 使用HttpClient Call Post API 
        /// 參數傳入字串
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string CallAPIPost(string url, string postData)
        {
            string result = string.Empty;

            //設置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //設置Http的內容標頭
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //設置Http的內容標頭的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";

            using (HttpClient client = new HttpClient())
            {
                //異步Post
                var response = client.PostAsync(url, httpContent).Result;
                
                //確保Http響應成功
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        #endregion

        #endregion

        #region Get

          #region 方法一

        /// <summary>
        /// 建議使用 CallAPIGet2
        /// 使用HttpClient Call Get API 
        /// 回傳Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T CallAPIGet<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIGet(url));
        }

        /// <summary>
        /// 建議使用 CallAPIGet2
        /// 使用HttpClient Call Get API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public XmlDocument CallAPIGetXml(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIGet(url));

            return doc;
        }

        /// <summary>
        /// 建議使用 CallAPIGet2
        /// 使用HttpClient Call Get API 
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string CallAPIGet(string url)
        {
            string result = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                result = client.GetStringAsync(url).Result;
            }

            return result;
        }

        #endregion

          #region 方法二 Good

        /// <summary>
        /// 使用HttpClient Call Get API 
        /// 回傳Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T CallAPIGet2<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIGet2(url));
        }

        /// <summary>
        /// 使用HttpClient Call Get API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public XmlDocument CallAPIGetXml2(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIGet2(url));

            return doc;
        }

        /// <summary>
        /// 使用HttpClient Call Get API 
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string CallAPIGet2(string url)
        {
            string result = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        #endregion

        #endregion

        #region Put

          #region 方法一 用Dictionary

        /// <summary>
        /// 使用HttpClient Call Put API 
        /// 回傳Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public T CallAPIPut<T>(string url, Dictionary<string, string> putData)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIPut(url, putData));
        }

        /// <summary>
        /// 使用HttpClient Call Put API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public XmlDocument CallAPIPutXml(string url, Dictionary<string, string> putData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIPut(url, putData));

            return doc;
        }


        /// <summary>
        /// 使用HttpClient Call Put API
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string CallAPIPut(string url, Dictionary<string, string> putData)
        {
            string result = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(putData);

                //異步Post
                var response = client.PutAsync(url, content).Result;

                //確保Http響應成功
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        #endregion

          #region 方法二 用string

        /// <summary>
        /// 使用HttpClient Call Put API 
        /// 參數傳入字串
        /// 回傳Json or Xml字串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public T CallAPIPut<T>(string url, string putData)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIPut(url, putData));
        }

        /// <summary>
        /// 使用HttpClient Call Put API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public XmlDocument CallAPIPutXml(string url, string putData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIPut(url, putData));

            return doc;
        }

        /// <summary>
        /// 使用HttpClient Call Put API
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="putData"></param>
        /// <returns></returns>
        public string CallAPIPut(string url, string putData)
        {
            string result = string.Empty;

            HttpContent httpContent = new StringContent(putData);

            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PutAsync(url, httpContent).Result;
   
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }
            
            return result;
        }

        #endregion

        #endregion

        #region Delete

        /// <summary>
        /// 使用HttpClient Call Delete API 
        /// 回傳Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T CallAPIDelete<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(CallAPIDelete(url));
        }

        /// <summary>
        /// 使用HttpClient Call Delete API 
        /// 回傳Xml
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public XmlDocument CallAPIDeleteXml(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(CallAPIDelete(url));

            return doc;
        }

        /// <summary>
        /// 使用HttpClient Call Delete API 
        /// 回傳Json or Xml字串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string CallAPIDelete(string url)
        {
            string result = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(url).Result;

                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        #endregion

        #endregion


    }
}
