using static System.Int32;

namespace BcxpChallenge;

/// <summary>
/// Holds the weather data and provides the temperature spread calculation.
/// </summary>
public class Weather
{
    private readonly int _day;
    private readonly int _maxTemperature;
    private readonly int _minTemperature;
    
    public int Day => _day;
    
    /// <summary>
    /// Constructor for the weather class taking string values for day, max and min temperature.
    /// </summary>
    /// <param name="day"> The day of the month </param>
    /// <param name="maxTemperature"> The maximum temperature on that day </param>
    /// <param name="minTemperature"> The minimum temperature on that day </param>
    public Weather(string day, string maxTemperature, string minTemperature)
    {
        _day = Parse(day);
        _maxTemperature = Parse(maxTemperature);
        _minTemperature = Parse(minTemperature);
    }
    
    /// <summary>
    /// Calculates the temperature spread for the weather data.
    /// </summary>
    /// <returns> The temperature spread </returns>
    public int CalculateTemperatureSpread()
    {
        return _maxTemperature - _minTemperature;
    }
}