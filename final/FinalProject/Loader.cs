namespace FinalProject;
using System.IO;
using System.Text.Json;
public class WeatherDataLoader
{
    private readonly string filePath;

    public WeatherDataLoader(string filePath)
    {
        this.filePath = filePath;
    }

    public WeatherData LoadWeatherData()
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);

            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonData);

            return weatherData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading weather data: {ex.Message}");
            return null;
        }
    }
}
