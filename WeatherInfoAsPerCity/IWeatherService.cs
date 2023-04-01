using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInfoAsPerCity
{
    public interface IWeatherService
    {
        public Task WeatherOperation(string city, string url);
    }
}
