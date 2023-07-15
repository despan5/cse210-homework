namespace FinalProject;
public class WeatherForecastApp
{
    private const string WeatherDataFilePath = @"C:\Users\mattd\Documents\cse210\cse210-homework-2\final\FinalProject\weatherinfo.json";
    private WeatherData weatherData;

    public void Run()
    {
        LoadWeatherData();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("==== Weather Forecast Menu ====");
            Console.WriteLine("1. View Current Weather Forecast");
            Console.WriteLine("2. View Daily Weather Forecast");
            Console.WriteLine("3. View 3 Day Weather Forecast");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    DisplayCurrentWeather();
                    break;
                case "2":
                    DisplayDailyForecast();
                    break;
                case "3":
                    Display3DayForecast();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void LoadWeatherData()
    {
        WeatherDataLoader loader = new WeatherDataLoader(WeatherDataFilePath);
        weatherData = loader.LoadWeatherData();

        if (weatherData == null)
        {
            Console.WriteLine("Weather data could not be loaded. Exiting...");
            Environment.Exit(1);
        }
    }

    private void DisplayCurrentWeather()
    {
        Location location = weatherData.location;
        CurrentWeather currentWeather = weatherData.current;

        if (currentWeather != null)
        {
            Console.WriteLine("==== Current Weather Forecast ====");
            CurrentWeatherForecast forecast = new CurrentWeatherForecast
            {
                _name = location.name,
                _country = location.country,
                _date = DateTimeOffset.FromUnixTimeSeconds(currentWeather.last_updated_epoch).DateTime,
                _summary = currentWeather.condition.text,
                _temperature = currentWeather.temp_c,
                _feelsLike = currentWeather.feelslike_c,
                _windKPH = currentWeather.wind_kph
            };

            forecast.Display();
        }
        else
        {
            Console.WriteLine("No current weather data available.");
        }
    }

    private void DisplayDailyForecast()
    {
    ForecastDay[] forecastDays = weatherData.forecast.forecastday;
    Location location = weatherData.location;

    if (forecastDays != null && forecastDays.Length > 0)
    {
        Console.WriteLine("==== Daily Weather Forecast ====");

        ForecastDay forecastDay = forecastDays[0];

        DailyWeatherForecast forecast = new DailyWeatherForecast
        {
            _name = location.name,
            _country = location.country,
            _date = DateTimeOffset.FromUnixTimeSeconds(forecastDay.date_epoch).DateTime,
            _summary = forecastDay.day.condition.text,
            _maxTemperature = forecastDay.day.maxtemp_c,
            _minTemperature = forecastDay.day.mintemp_c,
            _chanceOfRain = forecastDay.day.chance_of_rain
        };

        forecast.Display();
    }
    else
    {
        Console.WriteLine("No daily weather forecast data available.");
    }
    }

    private void Display3DayForecast()
    {
        ForecastDay[] forecastDays = weatherData.forecast.forecastday;
        Location location = weatherData.location;

        if (forecastDays != null)
        {
            Console.WriteLine("==== 3 Day Weather Forecast ====");

            foreach (var forecastDay in forecastDays)
            {
                ThreeDayWeatherForecast forecast = new ThreeDayWeatherForecast
                {
                    _name = location.name,
                    _country = location.country,
                    _date = DateTimeOffset.FromUnixTimeSeconds(forecastDay.date_epoch).DateTime,
                    _summary = forecastDay.day.condition.text,
                    _maxTemperature = forecastDay.day.maxtemp_c,
                    _minTemperature = forecastDay.day.mintemp_c,
                    _chanceOfRain = forecastDay.day.chance_of_rain
                };

                forecast.Display();
            }
        }
        else
        {
            Console.WriteLine("No weekly weather forecast data available.");
        }
    }
}