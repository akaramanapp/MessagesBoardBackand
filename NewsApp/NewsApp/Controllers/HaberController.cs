using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NewsApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HaberController : ApiController
    {
        public IEnumerable<Haber> GetAll(string query)
        {
            List<Haber> haberList = new List<Haber>();
            string uri = "https://api.hurriyet.com.tr/v1/" + query;  // articles?$filter=Path eq '/spor/'";

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("apikey: d22dd0d0eebb477083c999a8f5b5a852");
            string stringResponse = string.Empty;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                stringResponse = reader.ReadToEnd();
                var str = JsonConvert.DeserializeObject<List<Haber>>(stringResponse);
                foreach (var item in str)
                {
                    haberList.Add(new Haber { Description = item.Description, Title = item.Title, Path = item.Path, ModifiedDate = item.ModifiedDate, Files = item.Files });
                }
            }
            return haberList;
        }
    }

    public class Haber
    {
        public string Description { get; set; }
        public string Title { get; set; }

        public string Path { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<Files> Files { get; set; }
        //public string ID { get; set; }
        //public string Title { get; set; }
        //public string Content { get; set; }
        //public string Seo { get; set; }
        //public bool IsActive { get; set; }
        //public string Photo { get; set; }
        //public DateTime CreatedDate { get; internal set; }
    }

    public class Files
    {
        public string FileUrl { get; set; }
    }

}
