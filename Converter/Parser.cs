using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Converter
{
    public class Parser
    {
        public static Json parseJs()
        {
            Json Js;
            WebClient myClient = new WebClient();
            string json = myClient.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            return Js = JsonConvert.DeserializeObject<Json>(json);
        }
    }
}
