using WeatherInfoAsPerCity.Model;

namespace WeatherInfoAsPerCity
{
    public class WeatherService: IWeatherService
    {
        public async Task WeatherOperation(string city, string url)
        {
            try
            {              
               
                List<CityInfo> cityInfos = new List<CityInfo>();
                CityInfoRepository cityInfoRepository = new CityInfoRepository();
                cityInfos = cityInfoRepository.GetCityInfo();
                CityInfo cityInfo = new CityInfo();               

                cityInfo = cityInfos.FirstOrDefault(s => s.city_ascii.ToLower() == city?.ToLower());

                if (cityInfo != null)
                {
                    Dictionary<string, string> headers = new Dictionary<string, string>();
                    string formattedURL = string.Format(url, cityInfo.lat, cityInfo.lng);
                    HttpResponseMessage response = await HttpClientHelper.GetAsync(formattedURL, headers);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        WeatherDetail weatherDetail = await response.Content.ReadAsAsync<WeatherDetail>();

                        if (weatherDetail != null && weatherDetail.current_weather != null)
                        {
                            var cw = weatherDetail.current_weather;
                            Console.WriteLine("Weather Details: ");
                            Console.WriteLine("Temperature: {0}\tWind Speed: {1}\t     Wind Direction: {2}", cw.temperature, cw.windspeed, cw.winddirection);
                            Console.WriteLine("Weather Code: {0}\t      Time: {1}", cw.weathercode, cw.time);
                        }
                        else
                        {
                            Console.WriteLine("No Data in Response from API!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
                else
                {
                    Console.WriteLine("Please check, City Name do not matched!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred in WeatherOperation Method Message: " + ex.Message);
                Console.WriteLine("Error StackTrace: " + ex.StackTrace);
            }


        }

       

       

        
    }
}
