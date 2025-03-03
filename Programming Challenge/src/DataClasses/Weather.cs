namespace BcxpChallenge;

/// <summary>
/// Holds the weather data and calculates the temperature spread.
/// </summary>
public class Weather
{
    private int _day;
    private int _maxTemperature;
    private int _minTemperature;
    
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
    /// Constructor for the weather class taking string values for day, max and min temperature.
    /// </summary>
    /// <param name="day"> The day of the month </param>
    /// <param name="maxTemperature"> The maximum temperature on that day </param>
    /// <param name="minTemperature"> The minimum temperature on that day </param>
    public Weather(string day, string maxTemperature, string minTemperature)
    {
        _day = Int32.Parse(day);
        _maxTemperature = Int32.Parse(maxTemperature);
        _minTemperature = Int32.Parse(minTemperature);
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