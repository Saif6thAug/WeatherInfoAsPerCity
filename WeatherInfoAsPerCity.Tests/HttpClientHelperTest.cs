using System;
using System.Collections.Generic;
using System.Net.Http;
using WeatherInfoAsPerCity.Model;
using Xunit;

namespace WeatherInfoAsPerCity.Tests
{
    
    public class HttpClientHelperTest
    {
        [Fact]
        public async void CityInfo_DataPresent_Test()
        {
            var result = false;
            //For Kolkata City
            CityInfo cityInfo = new CityInfo()
            {
                lat = "22.5727",
                lng = "88.3639"
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            string formattedURL = string.Format(Constants.WeatherAPI, cityInfo.lat, cityInfo.lng);
            HttpResponseMessage response = await HttpClientHelper.GetAsync(formattedURL, headers);

            if (response != null && response.IsSuccessStatusCode)
            {
                WeatherDetail weatherDetail = await response.Content.ReadAsAsync<WeatherDetail>();

                if (weatherDetail != null && weatherDetail.current_weather != null)
                {
                    var cw = weatherDetail.current_weather;
                    if (!string.IsNullOrEmpty(Convert.ToString(cw.temperature)) &&
                        !string.IsNullOrEmpty(Convert.ToString(cw.windspeed)) &&
                        !string.IsNullOrEmpty(Convert.ToString(cw.winddirection)) &&
                        !string.IsNullOrEmpty(Convert.ToString(cw.weathercode)) &&
                        !string.IsNullOrEmpty(cw.time)
                        )
                    {
                        result = true;
                    }
                }
            }
            
            Assert.True(result, "All weather data should be present from Weather API.");
        }
    }
}
