using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;









//=====================JSON Model======================================
public class Avg_Dni_Object
{
    public double annual { get; set; }
}

public class OutputsObject
{
    public Avg_Dni_Object avg_dni { get; set; }
}

public class SunIntensityModel
{
    public string checkValue = "";
    public OutputsObject outputs { get; set; }
}
//======================================================================

public class SunIntensityProcessor // engine to url to model
{
    public static async Task<SunIntensityModel> LoadSunIntensityModel(double lat, double longitude)
    {
        
        string url = "";
        double localLatitude = lat;
        double localLongitude = longitude;
        
        // base url
        url =
            "https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=af9Pr6H2WleNc0oL3KolePr1ic5WCKospWH7cVXa&lat=33.4484&lon=-112.0740";
        // url for input
        string checkURL = String.Format("https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=af9Pr6H2WleNc0oL3KolePr1ic5WCKospWH7cVXa&lat={0}&lon={1}", localLatitude, localLongitude);

        using (HttpResponseMessage response = await ApiClientApiHelper.MyApiClient.GetAsync(checkURL)) // create a "browser" for our request
        {
            if (response.IsSuccessStatusCode) // is the response message from our request is successful
            {
                // convert the received JSON to the object model
                SunIntensityModel intensityModel = await response.Content.ReadAsAsync<SunIntensityModel>();
                // add the url to the model for debugging
                intensityModel.checkValue = checkURL;
                // return the model
                return intensityModel;
            }
            // if our request fails
            throw new Exception(response.ReasonPhrase);
        }
    }
}


//======================================================================
//===================Web Client========================================
public static class ApiClientApiHelper
{
    public static HttpClient MyApiClient { get; set; } // instantiate client

    public static void InitializeClient() // initialize webclient
    {

        MyApiClient = new HttpClient();  // initialize client
        MyApiClient.DefaultRequestHeaders.Accept.Clear(); // clear the header of the client as it is static
        // set the header of the client to receive JSON
        MyApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}


public class Service : IService
{
    private SunIntensityModel currentSunIntensityModel;

    public async Task<string> GetSolarIntensity(double latitude, double longitude)
    {
        ApiClientApiHelper.InitializeClient(); 
        await loadSunIntensityModelTask(latitude, longitude);
        // get sunshine value from model
        string sunShineValue = currentSunIntensityModel.outputs.avg_dni.annual.ToString();
        return sunShineValue;
    }

    private async Task loadSunIntensityModelTask(double lat, double longitude)
    {
        currentSunIntensityModel = await SunIntensityProcessor.LoadSunIntensityModel(lat , longitude);
    }
}
