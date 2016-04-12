using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class CheckTemp
    {
        string[] wind_direct = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };

        private string server_address = "http://api.openweathermap.org/data/2.5/";
        private string api_key = "21deb6b8280b4fe4036a7feba7b47c1a";
        private string icon_address = "http://openweathermap.org/img/w/";

        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public int Temp { get; set; }

        public WeatherData Data;

        public CheckTemp(string _city, int _temp)
        {
            City = _city;
            Temp = _temp;
        }

        public void downloadJson()
        {
            var api_url = server_address + "weather?q=" + City + "&appid=" + api_key;

            WebClient web_client = new WebClient();
            web_client.Encoding = Encoding.UTF8;
            var json = web_client.DownloadString(api_url);

            Data = JsonConvert.DeserializeObject<WeatherData>(json);
        }

        public override string ToString()
        {
            string list = "";

            DateTime search_date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            list += "Miasto:\t" + Data.name + "\n";

            list += "Data:\t" + search_date.AddSeconds(Data.dt).ToLocalTime().ToShortDateString() + "\n";
            list += "Czas:\t" + search_date.AddSeconds(Data.dt).ToLocalTime().ToShortTimeString() + "\n";

            list += "Temperatura:\t" + (Math.Truncate((Data.main.temp - 273.15) * 10) / 10).ToString() + " ℃\n";
            list += "Min. temp:\t" + (Math.Truncate((Data.main.temp_min - 273.15) * 10) / 10).ToString() + " ℃\n";
            list += "Max. temp:\t" + (Math.Truncate((Data.main.temp_max - 273.15) * 10) / 10).ToString() + " ℃\n";

            list += "Wilgotność:\t" + Data.main.humidity.ToString() + " %\n";
            list += "Ciśnienie:\t" + Data.main.pressure.ToString() + " hPa\n";

            list += "Prędkość wiatru:\t" + Data.wind.speed.ToString() + " m/s\n";
            list += "Kierunek wiatru:\t" + wind_direct[((int)((Data.wind.deg / 22.5) + .5)) % 16] + "\n";

            list += "Wschód słońca:\t" + search_date.AddSeconds(Data.sys.sunrise).ToLocalTime().ToShortTimeString() + "\n";
            list += "Zachód słońca:\t" + search_date.AddSeconds(Data.sys.sunset).ToLocalTime().ToShortTimeString() + "\n";

            return list;
        }
    }
}
