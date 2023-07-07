namespace FinalProject;

// ForecastWeekly class
public class ForecastWeekly : Forecast
{
    public ForecastWeekly(WeatherApp weatherApp) : base(weatherApp)
    {
    }

    public override async Task Display()
    {
        WeatherData weatherData = await weatherApp.GetWeatherData();
        Console.WriteLine($"Weekly Forecast in {weatherData.Location}:");
        int dayCount = 1;
        foreach (ForecastDay forecastDay in weatherData.DailyForecasts)
        {
            Console.WriteLine($"Day {dayCount++}");
            Console.WriteLine($"Date: {forecastDay.Date.ToShortDateString()}");
            Console.WriteLine($"Condition: {forecastDay.DayCondition.Text}");
            Console.WriteLine($"Max Temperature: {forecastDay.MaxTemperature}°C");
            Console.WriteLine($"Min Temperature: {forecastDay.MinTemperature}°C");
            Console.WriteLine();
        }
    }
}

