using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445Project3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWeather_Click(object sender, EventArgs e)
        {
            WeatherService1.ServiceClient weatherClient = new WeatherService1.ServiceClient();
            var theWeather = weatherClient.GetFiveDayForecast(12345);
            string[] days = theWeather.Split(',');

            labLocation.Text = days[0];
            labWeather1.Text = days[1];
            labWeather2.Text = days[2];
            labWeather3.Text = days[3];
            labWeather4.Text = days[4];
            labWeather5.Text = days[5];
        }
    }
}