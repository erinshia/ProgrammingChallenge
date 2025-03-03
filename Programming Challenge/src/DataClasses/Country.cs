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
    /// Constructor for the country class taking string values for name, population and area.
    /// </summary>
    /// <param name="name"> The name of the country </param>
    /// <param name="population"> The population of the country </param>
    /// <param name="area"> The area of the country </param>
    public Country(string name, string population, string area)
    {
        _name = name;
        
        _population = TryParseInt(population);
        _area = TryParseInt(area);
    }

    /// <summary>
    /// Try parsing the input as a normal int and if that fails, try parsing it as a decimal and casting it to int.
    /// </summary>
    /// <param name="input"> The string to parse </param>
    /// <returns> The parsed int </returns>
    private static int TryParseInt(string input)
    {
        var numberFormatInfo = new NumberFormatInfo
        {
            NumberGroupSeparator = ".",
            NumberDecimalSeparator = ","
        };
        
        if (int.TryParse(input, out int parsedInt))
        {
            return parsedInt;
        }

        if (decimal.TryParse(input, NumberStyles.Number, numberFormatInfo, out decimal parsedDecimal))
        {
            return (int)parsedDecimal;
        }
        
        throw new ArgumentException("Invalid input value: " + input);
    }

    /// <summary>
    /// Calculates the temperature spread for the weather data.
    /// </summary>
    /// <returns> The temperature spread </returns>
    public float CalculatePopulationDensity()
    {
        return (float)_population / _area;
    }
}