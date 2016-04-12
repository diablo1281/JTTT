using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTTT
{
    public partial class WeatherChecker : Form
    {
        CustomLogger logger = new CustomLogger();

        private const double zero_abs = 273.15;

        string[] wind_direct = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };

        private string icon_address = "http://openweathermap.org/img/w/";

        public WeatherChecker()
        {
            InitializeComponent();
        }

        private void buttonCheck_MouseClick(object sender, MouseEventArgs e)
        {
            var our_date = new CheckTemp(textBoxCity.Text, 0);
            our_date.downloadJson();
            setLabels(our_date.Data);
        }

        private void setLabels(WeatherData data)
        {
            DateTime search_date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            labelCity.Text = data.name;

            labelDate.Text = search_date.AddSeconds(data.dt).ToLocalTime().ToShortDateString();
            labelTime.Text = search_date.AddSeconds(data.dt).ToLocalTime().ToShortTimeString();

            labelTemp.Text = (Math.Truncate((data.main.temp - zero_abs) * 10) / 10).ToString() + " ℃";
            labelMinTemp.Text = (Math.Truncate((data.main.temp_min - zero_abs) * 10) / 10).ToString() + " ℃";
            labelMaxTemp.Text = (Math.Truncate((data.main.temp_max - zero_abs) * 10) / 10).ToString() + " ℃";

            labelHumidity.Text = data.main.humidity.ToString() + " %";
            labelPressure.Text = data.main.pressure.ToString() + " hPa";

            labelWindSpeed.Text = data.wind.speed.ToString() + " m/s";
            labelWindDirection.Text = wind_direct[((int)((data.wind.deg / 22.5) + .5)) % 16];

            labelSunriseTime.Text = search_date.AddSeconds(data.sys.sunrise).ToLocalTime().ToShortTimeString();
            labelSunsetTime.Text = search_date.AddSeconds(data.sys.sunset).ToLocalTime().ToShortTimeString();

            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.Load(icon_address + data.weather[0].icon + ".png");
            
        }

        private void textBoxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                var our_date = new CheckTemp(textBoxCity.Text, 0);
                our_date.downloadJson();
                setLabels(our_date.Data);
            }
        }
    }
}
