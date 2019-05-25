using System.IO;
using System.Net;
using CodingChallengeBusiness.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace CodingChallengePersistance.Utilities
{
    /// <summary>
    /// implementation of IMapUtility using Google map API
    /// </summary>
    public class MapUtility : IMapUtility
    {
        private readonly string _url;
        private readonly string _apiKey;

        public MapUtility(IConfiguration config)
        {
            _url = config["GoogleMapSettings:ApiUrl"];
            _apiKey = config["GoogleMapSettings:ApiKey"];
        }
        public decimal CalculateDistance(string origine, string destination)
        {
            string result = string.Empty;
            string url = string.Format(_url, origine, destination, _apiKey);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                JObject apiResult = JObject.Parse(result);
                var distance = decimal.Parse((string)apiResult["rows"][0]["elements"][0]["distance"]["value"]);
                return distance;
            }
            catch (System.Exception)
            {

                return -1;
            }

        }
    }
}