using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInfoAsPerCity
{
    public class Constants
    {
        public const string WeatherAPI = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true";
        public const string DBFile = "worldcities.csv";
    }
}
