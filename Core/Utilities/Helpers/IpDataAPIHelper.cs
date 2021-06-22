using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class IpDataAPIHelper
    {
        public static IpInfoData RunApi(string ip)
        {
            string apiKey = "0a2bd543cabfa44ec7179df3472a23205495ec5c85901ed6e74f1d87";
            string curl = "https://api.ipdata.co/" + ip + "?api-key=" + apiKey;
            IpInfoData ipInfo = JsonHelper<IpInfoData>.LoadJsonSoloData(curl);
            return ipInfo;
        }

    }

    public class IpInfoData
    {
        public string ip { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
    }
}
