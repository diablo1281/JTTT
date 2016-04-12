using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    [Serializable]
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    [Serializable]
    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    [Serializable]
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    [Serializable]
    public class Clouds
    {
        public int all { get; set; }
    }

    [Serializable]
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    [Serializable]
    public class WeatherData
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
