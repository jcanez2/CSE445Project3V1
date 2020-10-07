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

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public static class ApiHelper
{
    public static HttpClient ApiClient { get; set; }

    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        /*
        string baseAdd;
        baseAdd =
            @"https://api.openweathermap.org/data/2.5/onecall?lat=33.441792&lon=-94.037689&exclude=current,minutely,hourly,alerts&appid=0581321595fd5753f58de82a6035d871&units=imperial";
        */
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}

public class WeatherObject
{
    public string main { get; set; }
}

public class TemperatureObject
{
    public double max { get; set; }
    public double min { get; set; }

}

public class DailyObject
{
    public int sunrise { get; set; }

    public TemperatureObject temp { get; set; }

    public List<WeatherObject> weather { get; set; }

}


public class ForeCastModel
{
    public string timezone { get; set; }
    public int timezone_offset { get; set; }

    public List<DailyObject> daily { get; set; }
}

public class DailyForeCastObject
{
    public static async Task<ForeCastModel> LoadForecast()
    {

        string url = "";

        url =
            "https://api.openweathermap.org/data/2.5/onecall?lat=33.441792&lon=-94.037689&exclude=current,minutely,hourly,alerts&appid=0581321595fd5753f58de82a6035d871&units=imperial";

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                ForeCastModel report = await response.Content.ReadAsAsync<ForeCastModel>();
                return report;
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}

public class Service : IService
{
    private ForeCastModel currentForeCastModel;

    public async Task<string> GetFiveDayForecast(int zip)
    {
        ApiHelper.InitializeClient();
        await LoadForecastReport();
        string newTimezone = currentForeCastModel.timezone;
        int timeZoneOffset = currentForeCastModel.timezone_offset;
        List<DailyObject> myDailyObjects = currentForeCastModel.daily;

        DateTime theDates = DateTime.Today;

        string response = newTimezone + ",";
        for (int i = 0; i < 5; i++)
        {
            response += theDates.AddDays(i).ToString("MM/dd/yyyy") + ": High will be ";
            response += myDailyObjects[i].temp.max;
            response += "f\n : Low wil be ";
            response += myDailyObjects[i].temp.min;
            response += "f\n : Weather is ";
            response += myDailyObjects[i].weather[0].main;
            if (i != 4)
            {
                response += ",\n";
            }
        }

        return response;
    }

    private async Task LoadForecastReport()
    {
        currentForeCastModel = await DailyForeCastObject.LoadForecast();
    }
}
