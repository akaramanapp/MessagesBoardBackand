using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlinePay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Get());
        }

        public string Get()
        {
            string uri = "https://api.hurriyet.com.tr/v1/articles?$filter=Path eq '/gundem/'";
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("apikey: d22dd0d0eebb477083c999a8f5b5a852");
            string stringResponse = string.Empty;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                stringResponse = reader.ReadToEnd();
                return stringResponse;
                //var str = JsonConvert.DeserializeObject<IList>(stringResponse);
                //foreach (var item in str)
                //{

                //}
            }
        }
    }

}
public class Haber { 
   public string ID { get; set; }
   public string Title { get; set; }
   public string Content { get; set; }
   public string Seo { get; set; }
   public bool IsActive { get; set; }
   public string Photo { get; set; }
    public DateTime CreatedDate { get; internal set; }
}