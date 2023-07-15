namespace FinalProject;
public class CurrentWeatherForecast : WeatherForecast
{
    public override void Display()
    {
        Console.WriteLine($"City: {_name}");
        Console.WriteLine($"Country: {_country}");
        Console.WriteLine($"Today's Date: {_date.ToShortDateString()}");
        Console.WriteLine($"Summary: {_summary}");
        Console.WriteLine($"Temperature: {_temperature}°C");
        Console.WriteLine($"Wind speed: {_windKPH} KPH");
        Console.WriteLine($"Feel like: {_feelsLike}°C");
        Console.WriteLine();
    }
}