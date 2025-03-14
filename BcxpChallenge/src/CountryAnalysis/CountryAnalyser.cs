using BcxpChallenge.Utils;

namespace BcxpChallenge.CountryAnalysis;

/// <summary>
/// Provides methods to parse and analyse country data.
/// </summary>
public class CountryAnalyser : DataAnalyser<Country>
{
    private const int CountryDataFieldsCount = 5;
    private const int NameIndex = 0;
    private const int PopulationIndex = 3;
    private const int AreaIndex = 4;
    
    /// <summary>
    /// Parse data entries from the given string array into an instance of the Country class.
    /// </summary>
    /// <param name="date"> Contains the data for a Country instance. </param>
    /// <returns> An instance of the Country class containing the passed data. </returns>
    protected override Country ParseDataEntries(string[] date)
    {
        int population = NumberParsingUtils.TryParseIntInGermanFormatting(date[PopulationIndex]);
        int area = NumberParsingUtils.TryParseIntInGermanFormatting(date[AreaIndex]);
        Country country = new Country(date[NameIndex], population, area);
        return country;
    }

    /// <summary>
    /// Parses the country data from a list of string arrays into a list of Country objects.
    /// </summary>
    /// <param name="countryInput"> The lines of data already split at the separator. </param>
    /// <returns> A list of Country objects containing the data. </returns>
    public List<Country>? ParseCountryData(IEnumerable<string[]>? countryInput)
    {
        var countryData = ParseDataFromInput(countryInput, CountryDataFieldsCount);
        return countryData?.Count == 0 ? null : countryData;
    }
    
    /// <summary>
    /// Calculates the country with the highest population density from the given country data input.
    /// </summary>
    /// <param name="countryData"> List of Country data. </param>
    /// <returns> The name of the country with the highest population density. </returns>
    public static string FindCountryWithHighestPopulationDensity(List<Country> countryData)
    {
        var minSpread = countryData.MaxBy(x => x.CalculatePopulationDensity());
        return minSpread?.Name ?? "";
    }
}