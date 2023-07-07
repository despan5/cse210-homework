namespace FinalProject;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

// WeatherApp class
public class WeatherApp
{
    private WeatherAPI weatherAPI;
    private Menu menu;
    private double latitude;
    private double longitude;

    public WeatherApp(string apiKey)
    {
        weatherAPI = new WeatherAPI(apiKey);
        menu = new Menu(this);
    }

    public async Task Run()
    {
        Console.Write("Enter city name: ");
        string cityName = Console.ReadLine();

        await GetCoordinates(cityName);
        await menu.ProcessInput();
    }

    private async Task GetCoordinates(string cityName)
    {
        string geocodingApiUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid=4e316287cda887a206cb0fcf940dfbd5";

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(geocodingApiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                JsonDocument jsonDocument = JsonDocument.Parse(responseContent);
                JsonElement root = jsonDocument.RootElement;

                if (root.GetArrayLength() > 0)
                {
                    JsonElement location = root[0];
                    latitude = location.GetProperty("lat").GetDouble();
                    longitude = location.GetProperty("lon").GetDouble();
                }
                else
                {
                    Console.WriteLine("Failed to retrieve location coordinates. Please try again.");
                    await Run();
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve location coordinates. Please try again.");
                await Run();
            }
        }
    }

    public async Task<WeatherData> GetWeatherData()
    {
        return await weatherAPI.GetWeatherDataAsync(latitude, longitude);
    }

    public async Task DisplayForecast(Forecast forecast)
    {
        await forecast.Display();
    }
}