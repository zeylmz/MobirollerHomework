using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FindIpLocalization
    {
        public static string RequestLocalization(string ip)
        {
            IpInfoData clientIp = IpDataAPIHelper.RunApi(ip);
            string result = clientIp.country_name;
            return result;
        }
    }
}
