using BcxpChallenge.Utils;

namespace BcxpChallenge.WeatherAnalysis;

public class WeatherAnalyser : DataAnalyser<Weather>
{
    private const int WeatherDataFieldsCount = 3;
    private const int DayIndex = 0;
    private const int MaxTempIndex = 1;
    private const int MinTempIndex = 2;
    
    protected override Weather ParseDataEntries(string[] date)
    {
        int day = NumberParsingUtils.TryParseInt(date[DayIndex]);
        int maxTemp = NumberParsingUtils.TryParseInt(date[MaxTempIndex]);
        int minTemp = NumberParsingUtils.TryParseInt(date[MinTempIndex]);
        Weather weather = new Weather(day, maxTemp, minTemp);
        return weather;
    }
    
    /// <summary>
    /// Parses the weather data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Weather objects containing the data from the csv file </returns>
    public List<Weather>? ParseWeatherData(IEnumerable<string[]>? weatherInput)
    {
        var weatherData = ParseDataFromInput(weatherInput, WeatherDataFieldsCount);
        return weatherData?.Count == 0 ? null : weatherData;
    }
    
    /// <summary>
    /// Calculates the day with the lowest temperature spread from the given weather data input.
    /// </summary>
    /// <param name="weatherData"> List of Weather data </param>
    /// <returns> The day of the month with the lowest temperature spread </returns>
    public static int FindDayWithLowestTempSpread(List<Weather>? weatherData)
    {
        weatherData.Sort((x, y) => x.CalculateTemperatureSpread().CompareTo(y.CalculateTemperatureSpread()));
        return weatherData.First().Day;
    }
}