using IronXL;
using System.Data;
using WeatherInfoAsPerCity.Model;

namespace WeatherInfoAsPerCity
{
    public class CityInfoRepository
    {
        public List<CityInfo> GetCityInfo()
        {
            string sFile = GetPath(Constants.DBFile);

            var csvFilereader = ReadExcel(sFile);
            List<CityInfo> cityInfos = new List<CityInfo>();
            CityInfo cityInfo;
            for (int i = 1; i < csvFilereader.Rows.Count; i++)
            {
                cityInfo = new CityInfo()
                {
                    city_ascii = csvFilereader.Rows[i][1].ToString(),
                    lat = csvFilereader.Rows[i][2].ToString(),
                    lng = csvFilereader.Rows[i][3].ToString(),
                };
                cityInfos.Add(cityInfo);
            }

            return cityInfos;
        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable</returns>
        private static DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable(true);
        }

        private string GetPath(string fileName)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return System.IO.Path.Combine(sCurrentDirectory, fileName);
        }
    }
}
