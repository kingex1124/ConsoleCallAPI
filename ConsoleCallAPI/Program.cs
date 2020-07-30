using ConsoleCallAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleCallAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();

            string callAPIResult = pg.CallAPI("https://www.twse.com.tw/exchangeReport/TWT48U?response=json");

            var model = JsonConvert.DeserializeObject<JsonFirstData>(callAPIResult);

            List<MyJsonData> myJsonList = new List<MyJsonData>();
            foreach (var item in model.data)
            {
                MyJsonData mjd = new MyJsonData()
                {
                    Date = item[0],
                    Code = item[1],
                    Dividends = item[3],
                    CashDividend = item[7]
                };
                myJsonList.Add(mjd);
            }
            //https://www.tpex.org.tw/web/stock/exright/preAnnounce/PrePost_result.php?l=zh-tw&_=1595478097827
            string callAPIResult2 = pg.CallAPI("https://www.tpex.org.tw/web/stock/exright/preAnnounce/PrePost_result.php?l=zh-tw");

            var model2 = JsonConvert.DeserializeObject<JsonFirstData2>(callAPIResult2);

            List<MyJsonData> myJsonList2 = new List<MyJsonData>();
            foreach (var item in model2.aaData)
            {
                MyJsonData mjd = new MyJsonData()
                {
                    Date = item[0],
                    Code = item[1],
                    Dividends = item[3],
                    CashDividend = item[7]
                };
                myJsonList2.Add(mjd);
            }

            //取得Xml String
            string callAPIResult3 = pg.CallAPI("http://128.110.14.61/admin/SysSetup/CheckSum.aspx?m_actno=011714&bhno=all&day=20200730");

            // 讀取Xml資料
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(callAPIResult3);

            // 把Xml轉成Json
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            // 把Json 轉成Class
            var model3 = JsonConvert.DeserializeObject<XmlJsonData>(jsonText);

        }

        /// <summary>
        /// 呼叫API取得資料
        /// </summary>
        /// <param name="url"></param>
        public string CallAPI(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(new Uri(url)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string dataObjects = response.Content.ReadAsStringAsync().Result;//ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll

                return dataObjects;

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "False";
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
