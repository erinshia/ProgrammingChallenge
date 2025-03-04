using System.Globalization;

namespace BcxpChallenge;

/// <summary>
/// Holds the country data and provides the population density calculation.
/// </summary>
public class Country
{
    private readonly string _name;
    private readonly int _population;
    private readonly int _area;
    
    public string Name => _name;
    
    /// <summary>
    /// Constructor for the country class taking a name string and int values for population and area.
    /// </summary>
    /// <param name="name"> The name of the country </param>
    /// <param name="population"> The population of the country </param>
    /// <param name="area"> The area of the country </param>
    public Country(string name, int population, int area)
    {
        _name = name;
        
        _population = population;
        _area = area;
    }

    /// <summary>
    /// Calculates the population density for the country data.
    /// </summary>
    /// <returns> The population density </returns>
    public float CalculatePopulationDensity()
    {
        return (float)_population / _area;
    }
}