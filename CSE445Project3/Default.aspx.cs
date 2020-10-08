using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSE445Project3.CredentialsService1;

namespace CSE445Project3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWeather_Click(object sender, EventArgs e)
        {
            // Create service proxy
            WeatherService1.ServiceClient weatherClient = new WeatherService1.ServiceClient(); 
            try
            {
                int zipcode = Int32.Parse(txtWeather.Text); // convert entered text to int
                // send request to server passing in a zipcode
                var theWeather = weatherClient.GetFiveDayForecast(zipcode); 
                // split the return for use;
                string[] days = theWeather.Split(',');
                // assign each forcast to labels;
                labLocation.Text = days[0];
                labWeather1.Text = days[1];
                labWeather2.Text = days[2];
                labWeather3.Text = days[3];
                labWeather4.Text = days[4];
                labWeather5.Text = days[5];
            }
            catch (Exception)
            {
                // handle invalid input;
                labLocation.Text = "Invalid Input Try Again, enter a US Zip Code";
            }
        }

        protected void btnSunShine_Click(object sender, EventArgs e)
        {
            // create service proxy
            SolarService1.ServiceClient solarClient = new SolarService1.ServiceClient();
            try
            {
                // convert entered text to double values
                double latitude = Double.Parse(txtbLat.Text);
                double longitude = Double.Parse(txtbLong.Text);
                
                // call server to get solar index
                var solarIndex = solarClient.GetSolarIntensity(latitude, longitude);

                labSolarIndex.Text = solarIndex; // set the lab to solar index value
            }
            catch (Exception)
            {
                // set exception message
                labSolarIndex.Text = "Invalid Input Try Again, enter a Latitude and Longitude as a number value";
            }
        }

        protected void btnCredentials_Click(object sender, EventArgs e)
        {
            // create client proxy
            CredentialsService1.ServiceClient credClient = new ServiceClient();
            try
            {
                // have serve validate username and password
                labResponseMessage.Text = credClient.SubmitUserCredentials(txtUserName.Text, txtPassword.Text);
                if (labResponseMessage.Text == "This is a Valid User")
                {
                    labResponseMessage.ForeColor = Color.Chartreuse; // change color is valid
                }
                else
                {
                    labResponseMessage.ForeColor = Color.Black; // set color back if !valid
                }
            }
            catch (Exception ex)
            {
                labResponseMessage.Text = ex.Message; // handle exception;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // create proxy client
            FileUploadService1.ServiceClient fileUploadClient = new FileUploadService1.ServiceClient();
            try
            {
                if (FileUpload1.HasFile) // if file browser has selected a file
                {
                    // change the name to the incoming file
                    fileUploadClient.SendFileName(FileUpload1.FileName);

                    if (FileUpload1.FileName.EndsWith(".txt")) // if the file is a text file
                    {
                        // create a stream from the file contents
                        var fileAsStream = FileUpload1.FileContent;
                        // send stream to serve and get file upload location
                        string returnFilePath = fileUploadClient.SendFileAsStream(fileAsStream);
                        // return the upload location to the user
                        labReturnPath.Text = returnFilePath;
                    }
                    else // if file is not a text file
                    {
                        labReturnPath.Text = "File must be a text file ending in .txt";
                    }
                }
                else // if file browser has not selected a file
                {
                    labReturnPath.Text = "Please Select A File!";
                }
            }
            catch (Exception ex)
            {
                // handle exception
                labReturnPath.Text = ex.Message;
            }
        }
    }
}