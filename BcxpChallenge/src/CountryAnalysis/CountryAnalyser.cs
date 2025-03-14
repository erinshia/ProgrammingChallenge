using BcxpChallenge.Utils;

namespace BcxpChallenge.CountryAnalysis;

public class CountryAnalyser : DataAnalyser<Country>
{
    private const int CountryDataFieldsCount = 5;
    private const int NameIndex = 0;
    private const int PopulationIndex = 3;
    private const int AreaIndex = 4;

    protected override Country ParseDataEntries(string[] date)
    {
        int population = NumberParsingUtils.TryParseInt(date[PopulationIndex]);
        int area = NumberParsingUtils.TryParseInt(date[AreaIndex]);
        Country country = new Country(date[NameIndex], population, area);
        return country;
    }

    /// <summary>
    /// Parses the country data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Country objects containing the data from the csv file </returns>
    public List<Country>? ParseCountryData(IEnumerable<string[]>? countryInput)
    {
        var countryData = ParseDataFromInput(countryInput, CountryDataFieldsCount);
        return countryData?.Count == 0 ? null : countryData;
    }
    
    /// <summary>
    /// Calculates the country with the highest population density.
    /// </summary>
    /// <param name="countryData"> List of Country data </param>
    /// <returns> The name of the country with the highest population density </returns>
    public static string FindCountryWithHighestPopulationDensity(List<Country> countryData)
    {
        var minSpread = countryData.MaxBy(x => x.CalculatePopulationDensity());
        return minSpread?.Name ?? "";
    }
}