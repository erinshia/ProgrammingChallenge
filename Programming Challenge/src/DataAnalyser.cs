namespace BcxpChallenge;

/// <summary>
/// Provides data analysis methods.
/// </summary>
public class DataAnalyser
{
    /// <summary>
    /// Calculates the day with the lowest temperature spread from the given weather data input.
    /// </summary>
    /// <param name="weatherData"> List of Weather data </param>
    /// <returns> The day of the month with the lowest temperature spread </returns>
    public static int FindDayWithLowestTempSpread(List<Weather> weatherData)
    {
        weatherData.Sort((x, y) => x.CalculateTemperatureSpread().CompareTo(y.CalculateTemperatureSpread()));
        return weatherData[0].Day;
    }
}