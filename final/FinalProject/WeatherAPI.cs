namespace FinalProject;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

// WeatherAPI class
public class WeatherAPI
{
    public string apiKey = "4e316287cda887a206cb0fcf940dfbd5";

    public WeatherAPI(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude)
    {
        string apiUrl = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid=4e316287cda887a206cb0fcf940dfbd5";

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = ParseWeatherData(responseContent);
                return weatherData;
            }
            else
            {
                Console.WriteLine("Failed to retrieve weather data. Status Code: " + response.StatusCode);
            }
        }

        return null;
    }

    private WeatherData ParseWeatherData(string responseContent)
    {
        using (JsonDocument jsonDocument = JsonDocument.Parse(responseContent))
        {
            JsonElement root = jsonDocument.RootElement;
            string location = root.GetProperty("timezone").GetString();

            // Get current weather
            JsonElement currentWeather = root.GetProperty("current");
            Condition currentCondition = new Condition(currentWeather.GetProperty("weather")[0].GetProperty("description").GetString());
            double currentTemperature = currentWeather.GetProperty("temp").GetDouble();
            int currentCloudCover = currentWeather.GetProperty("clouds").GetInt32();

            // Get daily forecasts
            List<ForecastDay> dailyForecasts = new List<ForecastDay>();
            JsonElement dailyForecastArray = root.GetProperty("daily");
            foreach (JsonElement dailyForecastElement in dailyForecastArray.EnumerateArray())
            {
                long unixTime = dailyForecastElement.GetProperty("dt").GetInt64();
                DateTime date = DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
                Condition dayCondition = new Condition(dailyForecastElement.GetProperty("weather")[0].GetProperty("description").GetString());
                double maxTemperature = dailyForecastElement.GetProperty("temp").GetProperty("max").GetDouble();
                double minTemperature = dailyForecastElement.GetProperty("temp").GetProperty("min").GetDouble();
                double precipitation = dailyForecastElement.GetProperty("pop").GetDouble();
                int cloudCover = dailyForecastElement.GetProperty("clouds").GetInt32();

                ForecastDay forecastDay = new ForecastDay(date, dayCondition, maxTemperature, minTemperature, precipitation, cloudCover);
                dailyForecasts.Add(forecastDay);
            }

            WeatherData weatherData = new WeatherData(location, currentCondition, currentTemperature, currentCloudCover, dailyForecasts);
            return weatherData;
        }
    }
}

