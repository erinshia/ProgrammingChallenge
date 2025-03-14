using BcxpChallenge;

namespace Tests.CountryAnalysis;

public class CountryTest
{
    /// <summary>
    /// Test the population density calculation.
    /// </summary>
    [Test]
    public void PopulationDensity_CalculatedCorrectlyByDividingPopulationByArea_WhenGivenValidInput()
    {
        Country testCountry = new Country("TestCountry", 10, 100);
        Assert.That(testCountry.CalculatePopulationDensity(), Is.EqualTo(0.1f));
    }
    
    /// <summary>
    /// Test the population density calculation.
    /// </summary>
    [Test]
    public void PopulationDensity_Returns0_WhenGiven0Population()
    {
        Country testCountry = new Country("TestCountry", 0, 100);
        Assert.That(testCountry.CalculatePopulationDensity(), Is.EqualTo(0));
    }
    
    /// <summary>
    /// Test the population density calculation.
    /// </summary>
    [Test]
    public void PopulationDensity_Returns0_WhenGiven0Area()
    {
        Country testCountry = new Country("TestCountry", 10, 0);
        Assert.That(testCountry.CalculatePopulationDensity(), Is.EqualTo(0));
    }
}