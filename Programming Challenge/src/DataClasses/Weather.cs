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
    /// Constructor for the weather class taking int values for day, max and min temperature.
    /// </summary>
    /// <param name="day"> The day of the month </param>
    /// <param name="maxTemperature"> The maximum temperature on that day </param>
    /// <param name="minTemperature"> The minimum temperature on that day </param>
    public Weather(int day, int maxTemperature, int minTemperature)
    {
        _day = day;
        _maxTemperature = maxTemperature;
        _minTemperature = minTemperature;
    }
    
    /// <summary>
    /// Calculates the absolute temperature spread for the weather data. 
    /// </summary>
    /// <returns> The absolute value of the temperature spread </returns>
    public int CalculateTemperatureSpread()
    {
        return Math.Abs(_maxTemperature - _minTemperature);
    }
}