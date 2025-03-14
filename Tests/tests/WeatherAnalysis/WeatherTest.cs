using BcxpChallenge;

namespace Tests.WeatherAnalysis;

public class WeatherTest
{
    /// <summary>
    /// Test the temperature spread calculation with positive min and max temperature.
    /// </summary>
    [Test]
    public void TemperatureSpread_CalculatedCorrectlyByAbsoluteOfSubtractionOfMinTempFromMaxTemp_WhenGivenPositiveTemperatures()
    {
        Weather testWeather = new Weather(1, 10, 5);
        Assert.That(testWeather.CalculateTemperatureSpread(), Is.EqualTo(5));
    }
    
    /// <summary>
    /// Test the temperature spread calculation with positive max and negative min temperature.
    /// </summary>
    [Test]
    public void TemperatureSpread_CalculatedCorrectlyByAbsoluteOfSubtractionOfMinTempFromMaxTemp_WhenGivenPositiveMaxTempAndNegativeMinTemp()
    {
        Weather testWeather = new Weather(1, 10, -5);
        Assert.That(testWeather.CalculateTemperatureSpread(), Is.EqualTo(15));
    }

    /// <summary>
    /// Test the temperature spread calculation for swapped minTemp and maxTemp.
    /// </summary>
    [Test]
    public void TemperatureSpread_CalculatedCorrectlyByAbsoluteOfSubtractionOfMinTempFromMaxTemp_WhenGivenSwappedMinMaxTemps()
    {
        Weather testWeather = new Weather(1, -5, 10);
        Assert.That(testWeather.CalculateTemperatureSpread(), Is.EqualTo(15));
    }
}