﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public static class ApiHelperApiClient
{
    public static HttpClient MyApiClient { get; set; } // instantiate client

    public static void InitializeClient() // initialize client
    {
        MyApiClient = new HttpClient();
        MyApiClient.DefaultRequestHeaders.Accept.Clear();
        MyApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}

//==================JSON object model==================
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

public class CorrdObject
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class CorrdByZipModel
{
    public CorrdObject coord { get; set; }
    public string name { get; set; }
}

//=========================================================================

public class DailyForeCastObject // Forecast processor json to object model
{
    public static async Task<ForeCastModel> LoadForecast(int zip)
    {
        
        string url = "";
        double longitude;
        double latitude;
        int enteredZip = zip;
        string cityName = "blank";

        // set up api call based on input of zip to get coordinates
        url = 
            string.Format(
                "http://api.openweathermap.org/data/2.5/weather?zip={0},us&appid=0581321595fd5753f58de82a6035d871", enteredZip);
        // get response from api call for latitude and longitude
        using (HttpResponseMessage response = await ApiHelperApiClient.MyApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode) // if response is successful
            {
                CorrdByZipModel coordinates = await response.Content.ReadAsAsync<CorrdByZipModel>();
                longitude = coordinates.coord.lon;
                latitude = coordinates.coord.lat;
                cityName = coordinates.name;
            }
            else // if response not successful
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
        // sep up api call with newly retrieved values from the last api call
        url =
            string.Format(
                "https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&exclude=current,minutely,hourly,alerts&appid=0581321595fd5753f58de82a6035d871&units=imperial",
                latitude, longitude);
        // make the api call and get response
        using (HttpResponseMessage response = await ApiHelperApiClient.MyApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                ForeCastModel report = await response.Content.ReadAsAsync<ForeCastModel>();
                report.timezone = cityName;
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
        ApiHelperApiClient.InitializeClient();
        await LoadForecastReport(zip);
        string newTimezone = currentForeCastModel.timezone;
        int timeZoneOffset = currentForeCastModel.timezone_offset;
        List<DailyObject> myDailyObjects = currentForeCastModel.daily;

        DateTime theDates = DateTime.Today;

        //================Set up the reponse for ease of parsing===========
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
        //========================================

        return response;
    }

    private async Task LoadForecastReport(int zip)
    {
        // load the forecast report object in to the global model
        currentForeCastModel = await DailyForeCastObject.LoadForecast(zip);
    }
}
