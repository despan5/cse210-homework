namespace FinalProject;
public class DailyWeatherForecast : WeatherForecast
{
    public override void Display()
    {
        Console.WriteLine($"City: {_name}");
        Console.WriteLine($"Country: {_country}");
        Console.WriteLine($"Today's date - {_date.ToShortDateString()}");
        Console.WriteLine($"Summary: {_summary}");
        Console.WriteLine($"Maximum temperature: {_maxTemperature}°C");
        Console.WriteLine($"Minimum temperature: {_minTemperature}°C");
        Console.WriteLine($"Chance of rain: {_chanceOfRain}%");
        Console.WriteLine();
    }
}