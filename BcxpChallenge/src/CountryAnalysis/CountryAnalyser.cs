using BcxpChallenge.Utils;

namespace BcxpChallenge.CountryAnalysis;

public static class CountryAnalyser
{
    private const int CountryDataFieldsCount = 5;
    private const int NameIndex = 0;
    private const int PopulationIndex = 3;
    private const int AreaIndex = 4;

    /// <summary>
    /// Parses the country data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Country objects containing the data from the csv file </returns>
    public static List<Country>? ParseCountriesFile(IEnumerable<string[]>? countryInput)
    {
        if (countryInput == null) return null;
        
        var countryData = new List<Country>();
        foreach (var date in countryInput)
        {
            // If this entry doesn't contain enough data, skip it
            if(date.Length < CountryDataFieldsCount)
            {
                Console.WriteLine("Invalid country data, skipping entry");
                continue;
            }

            try
            {
                int population = NumberParsingUtils.TryParseInt(date[PopulationIndex]);
                int area = NumberParsingUtils.TryParseInt(date[AreaIndex]);
                Country country = new Country(date[NameIndex], population, area);
                countryData.Add(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing country data: " + ex);
            }
        }

        return countryData.Count == 0 ? null : countryData;
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