namespace FinalProject;

// Forecast class
public abstract class Forecast
{
    protected WeatherApp weatherApp;

    public Forecast(WeatherApp weatherApp)
    {
        this.weatherApp = weatherApp;
    }

    public abstract Task Display();
}

