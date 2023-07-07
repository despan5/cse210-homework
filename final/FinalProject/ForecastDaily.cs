namespace FinalProject;

// ForecastDaily class
public class ForecastDaily : Forecast
{
    public ForecastDaily(WeatherApp weatherApp) : base(weatherApp)
    {
    }

    public override async Task Display()
    {
        WeatherData weatherData = await weatherApp.GetWeatherData();
        Console.WriteLine($"Daily Forecast in {weatherData.Location}:");
        foreach (ForecastDay forecastDay in weatherData.DailyForecasts)
        {
            Console.WriteLine($"Date: {forecastDay.Date.ToShortDateString()}");
            Console.WriteLine($"Condition: {forecastDay.DayCondition.Text}");
            Console.WriteLine($"Max Temperature: {forecastDay.MaxTemperature}°C");
            Console.WriteLine($"Min Temperature: {forecastDay.MinTemperature}°C");
            Console.WriteLine();
        }
    }
}

