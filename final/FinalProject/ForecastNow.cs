namespace FinalProject;

// ForecastNow class
public class ForecastNow : Forecast
{
    public ForecastNow(WeatherApp weatherApp) : base(weatherApp)
    {
    }

    public override async Task Display()
    {
        WeatherData weatherData = await weatherApp.GetWeatherData();
        Console.WriteLine($"Current Weather in {weatherData.Location}:");
        Console.WriteLine($"Condition: {weatherData.CurrentCondition.Text}");
        Console.WriteLine($"Temperature: {weatherData.CurrentTemperature}°C");
        Console.WriteLine($"Cloud Cover: {weatherData.CurrentCloudCover}%");
        Console.WriteLine();
    }
}
