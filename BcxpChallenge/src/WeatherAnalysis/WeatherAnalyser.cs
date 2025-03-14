using BcxpChallenge.Utils;

namespace BcxpChallenge.WeatherAnalysis;

/// <summary>
/// Provides methods to parse and analyse weather data.
/// </summary>
public class WeatherAnalyser : DataAnalyser<Weather>
{
    private const int WeatherDataFieldsCount = 3;
    private const int DayIndex = 0;
    private const int MaxTempIndex = 1;
    private const int MinTempIndex = 2;

    /// <summary>
    /// Parse data entries from the given string array into an instance of the Weather class.
    /// </summary>
    /// <param name="date"> Contains the data for a Weather instance. </param>
    /// <returns> An instance of the Weather class containing the passed data. </returns>
    protected override Weather ParseDataEntries(string[] date)
    {
        int day = NumberParsingUtils.TryParseIntInGermanFormatting(date[DayIndex]);
        int maxTemp = NumberParsingUtils.TryParseIntInGermanFormatting(date[MaxTempIndex]);
        int minTemp = NumberParsingUtils.TryParseIntInGermanFormatting(date[MinTempIndex]);
        Weather weather = new Weather(day, maxTemp, minTemp);
        return weather;
    }
    
    /// <summary>
    /// Parses the weather data from a list of string arrays into a list of Weather objects.
    /// </summary>
    /// <param name="weatherInput"> The lines of data already split at the separator. </param>
    /// <returns> A list of Weather objects containing the data. </returns>
    public List<Weather>? ParseWeatherData(IEnumerable<string[]>? weatherInput)
    {
        var weatherData = ParseDataFromInput(weatherInput, WeatherDataFieldsCount);
        return weatherData?.Count == 0 ? null : weatherData;
    }
    
    /// <summary>
    /// Calculates the day with the lowest temperature spread from the given weather data input.
    /// </summary>
    /// <param name="weatherData"> List of Weather data. </param>
    /// <returns> The day of the month with the lowest temperature spread. </returns>
    public static int FindDayWithLowestTempSpread(List<Weather> weatherData)
    {
        var minSpread = weatherData.MinBy(x => x.CalculateTemperatureSpread());
        return minSpread?.Day ?? 0;
    }
}