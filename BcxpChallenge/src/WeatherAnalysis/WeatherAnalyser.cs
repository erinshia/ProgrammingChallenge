using BcxpChallenge.Utils;

namespace BcxpChallenge.WeatherAnalysis;

public static class WeatherAnalyser
{
    private const int WeatherDataFieldsCount = 3;
    private const int DayIndex = 0;
    private const int MaxTempIndex = 1;
    private const int MinTempIndex = 2;
    
    /// <summary>
    /// Parses the weather data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Weather objects containing the data from the csv file </returns>
    public static List<Weather>? ParseWeatherFile(IEnumerable<string[]>? weatherInput)
    {
        if (weatherInput == null) return null;
        
        var weatherData = new List<Weather>();
        foreach (var date in weatherInput)
        {
            // If this entry doesn't contain enough data, skip it
            if(date.Length < WeatherDataFieldsCount)
            {
                Console.WriteLine("Invalid weather data, skipping entry");
                continue;
            }

            try
            {
                int day = NumberParsingUtils.TryParseInt(date[DayIndex]);
                int maxTemp = NumberParsingUtils.TryParseInt(date[MaxTempIndex]);
                int minTemp = NumberParsingUtils.TryParseInt(date[MinTempIndex]);
                Weather weather = new Weather(day, maxTemp, minTemp);
                weatherData.Add(weather);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing weather data, skipping entry: " + ex);
            }
        }

        return weatherData.Count == 0 ? null : weatherData;
    }

    
    /// <summary>
    /// Calculates the day with the lowest temperature spread from the given weather data input.
    /// </summary>
    /// <param name="weatherData"> List of Weather data </param>
    /// <returns> The day of the month with the lowest temperature spread </returns>
    public static int FindDayWithLowestTempSpread(List<Weather> weatherData)
    {
        weatherData.Sort((x, y) => x.CalculateTemperatureSpread().CompareTo(y.CalculateTemperatureSpread()));
        return weatherData.First().Day;
    }
}