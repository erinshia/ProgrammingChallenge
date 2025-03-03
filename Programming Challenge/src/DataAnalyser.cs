namespace BcxpChallenge;

/// <summary>
/// Provides data analysis methods.
/// </summary>
public static class DataAnalyser
{
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
    
    /// <summary>
    /// Calculates the country with the highest population density.
    /// </summary>
    /// <param name="countryData"> List of Country data </param>
    /// <returns> The name of the country with the highest population density </returns>
    public static string FindCountryWithHighestPopulationDensity(List<Country> countryData)
    {
        countryData.Sort((x, y) => x.CalculatePopulationDensity().CompareTo(y.CalculatePopulationDensity()));
        return countryData.Last().Name;
    }
}