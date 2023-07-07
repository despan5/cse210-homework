namespace FinalProject;

// WeatherData class
public class WeatherData
{
    public string Location { get; }
    public Condition CurrentCondition { get; }
    public double CurrentTemperature { get; }
    public int CurrentCloudCover { get; }
    public List<ForecastDay> DailyForecasts { get; }

    public WeatherData(string location, Condition currentCondition,
        double currentTemperature, int currentCloudCover, List<ForecastDay> dailyForecasts)
    {
        Location = location;
        CurrentCondition = currentCondition;
        CurrentTemperature = currentTemperature;
        CurrentCloudCover = currentCloudCover;
        DailyForecasts = dailyForecasts;
    }
}

