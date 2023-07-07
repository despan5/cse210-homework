namespace FinalProject;

// ForecastPrecipitation class
public class ForecastPrecipitation : Forecast
{
    public ForecastPrecipitation(WeatherApp weatherApp) : base(weatherApp)
    {
    }

    public override async Task Display()
    {
        WeatherData weatherData = await weatherApp.GetWeatherData();
        Console.WriteLine($"Precipitation Information in {weatherData.Location}:");
        foreach (ForecastDay forecastDay in weatherData.DailyForecasts)
        {
            Console.WriteLine($"Date: {forecastDay.Date.ToShortDateString()}");
            Console.WriteLine($"Precipitation: {forecastDay.Precipitation}%");
            Console.WriteLine();
        }
    }
}
