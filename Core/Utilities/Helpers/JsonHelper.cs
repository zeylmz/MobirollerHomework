using Core.Utilities.Results.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class JsonHelper<TEntity>
    {
        public static List<TEntity> LoadJson(string url)
        {
            using (var webClient = new WebClient())
            {
                string jsonData = webClient.DownloadString(url);
                List<TEntity> events = JsonConvert.DeserializeObject<List<TEntity>>(jsonData);
                return events;
            }
        }

        public static TEntity LoadJsonSoloData(string url)
        {
            using (var webClient = new WebClient())
            {
                string jsonData = webClient.DownloadString(url);
                TEntity events = JsonConvert.DeserializeObject<TEntity>(jsonData);
                return events;
            }
        } 
    }
}
