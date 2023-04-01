
namespace WeatherInfoAsPerCity
{
    class Program
    {

        public static void Main()
        {            
            try
            {
                Console.WriteLine("Welcome to Weather Info Tool");

                Console.Write("Please enter City Name for Weather Info: ");
                string city = Console.ReadLine();
                Console.WriteLine("Please wait....");
                IWeatherService weatherService = new WeatherService();
                if (!string.IsNullOrEmpty(city))
                {
                    weatherService.WeatherOperation(city, Constants.WeatherAPI).Wait();
                }
                else
                {
                    Console.WriteLine("City Name is null or empty!");
                }
                

                Console.WriteLine("Weather Info Tool Process Completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
                Console.WriteLine("Error StackTrace: " + ex.StackTrace);
            }


        }

        

    }
}
