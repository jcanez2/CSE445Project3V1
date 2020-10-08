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

public class SunIntensityProcessor
{
    public static async Task<SunIntensityModel> LoadSunIntensityModel(double lat, double longitude)
    {
        
        string url = "";
        double localLatitude = lat;
        double localLongitude = longitude;
        

        url =
            "https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=af9Pr6H2WleNc0oL3KolePr1ic5WCKospWH7cVXa&lat=33.4484&lon=-112.0740";

        string checkURL = String.Format("https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=af9Pr6H2WleNc0oL3KolePr1ic5WCKospWH7cVXa&lat={0}&lon={1}", localLatitude, localLongitude);

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(checkURL))
        {
            if (response.IsSuccessStatusCode)
            {
                SunIntensityModel intensityModel = await response.Content.ReadAsAsync<SunIntensityModel>();

                intensityModel.checkValue = checkURL;

                return intensityModel;
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}


//======================================================================
//===================Web Client========================================
public static class ApiHelper
{
    public static HttpClient ApiClient { get; set; } // create web client

    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}


public class Service : IService
{
    private SunIntensityModel currentSunIntensityModel;

    public async Task<string> GetSolarIntensity(double latitude, double longitude)
    {
        ApiHelper.InitializeClient();
        await loadSunIntensityModelTask(latitude, longitude);
        string sunShineValue = currentSunIntensityModel.outputs.avg_dni.annual.ToString();
        //string sunShineValue = currentSunIntensityModel.checkValue;
        return sunShineValue;
    }

    private async Task loadSunIntensityModelTask(double lat, double longitude)
    {
        currentSunIntensityModel = await SunIntensityProcessor.LoadSunIntensityModel(lat , longitude);
    }
}
