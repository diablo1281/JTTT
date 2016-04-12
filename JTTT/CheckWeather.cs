using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class CheckWeather
    {
        public string City { get; set; }
        public int Temp { get; set; }

        public CheckWeather(string _city, int _temp)
        {
            City = _city;
            Temp = _temp;
        }
    }
}
