using Xunit;

namespace WeatherInfoAsPerCity.Tests
{
    public class CityInfoRepositoryTest
    {
        [Fact]
        public void CityInfo_DataPresent_Test()
        {
            CityInfoRepository cityInfoRepository = new CityInfoRepository();
            var cityInfos = cityInfoRepository.GetCityInfo();
            var result = cityInfos != null && cityInfos.Count > 0 ? true : false;

            Assert.True(result, "DB data should be present.");            
        }
    }
}