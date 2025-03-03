using System.Globalization;

namespace BcxpChallenge;

public class Country
{
    private string _name;
    private int _population;
    private float _area;
    
    public string Name => _name;
    
    
    /// <summary>
    /// Constructor for the country class taking string value for day, and int values for max and min temperature.
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
    /// Constructor for the country class taking string values for name, population and area.
    /// </summary>
    /// <param name="name"> The name of the country </param>
    /// <param name="population"> The population of the country </param>
    /// <param name="area"> The area of the country </param>
    public Country(string name, string population, string area)
    {
        _name = name;
        
        var numberFormatInfo = new NumberFormatInfo
        {
            NumberGroupSeparator = ".",
            NumberDecimalSeparator = ","
        };

        if (Int32.TryParse(population, out int parsedPopInt))
        {
            _population = parsedPopInt;
        }
        else if (Decimal.TryParse(population, NumberStyles.Number, numberFormatInfo, out decimal parsedPopDecimal))
        {
            _population = (int)parsedPopDecimal;
        }
        else
        {
            throw new ArgumentException("Invalid population value");
        }
        
        if (Int32.TryParse(area, out int parsedAreaInt))
        {
            _area = parsedAreaInt;
        }
        else if (Decimal.TryParse(area, NumberStyles.Number, numberFormatInfo, out decimal parsedAreaDecimal))
        {
            _area = (int)parsedAreaDecimal;
        }
        else
        {
            throw new ArgumentException("Invalid population value");
        }
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