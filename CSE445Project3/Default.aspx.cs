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
            try
            {
                int zipcode = Int32.Parse(txtWeather.Text);
                var theWeather = weatherClient.GetFiveDayForecast(zipcode);
                string[] days = theWeather.Split(',');

                labLocation.Text = days[0];
                labWeather1.Text = days[1];
                labWeather2.Text = days[2];
                labWeather3.Text = days[3];
                labWeather4.Text = days[4];
                labWeather5.Text = days[5];
            }
            catch (Exception)
            {
                labLocation.Text = "Invalid Input Try Again, enter a US Zip Code";
            }
        }

        protected void btnSunShine_Click(object sender, EventArgs e)
        {
            
            SolarService1.ServiceClient solarClient = new SolarService1.ServiceClient();
            try
            {
                double latitude = Double.Parse(txtbLat.Text);
                double longitude = Double.Parse(txtbLong.Text);

                var solarIndex = solarClient.GetSolarIntensity(latitude, longitude);

                labSolarIndex.Text = solarIndex;
            }
            catch (Exception)
            {
                labSolarIndex.Text = "Invalid Input Try Again, enter a Latitude and Longitude as a number value";
            }
        }
    }
}