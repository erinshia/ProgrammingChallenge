using BcxpChallenge;
using BcxpChallenge.FileParser;

namespace Tests
{
    /// <summary>
    /// NUnit tests to test the functionality of the programm.
    /// </summary>
    public class AppTest
    {
        private CsvFileReader _csvFileReader;

        /// <summary>
        /// Setting up the csv file reader for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _csvFileReader = new CsvFileReader();
        }
        
        /// <summary>
        /// Test if the correct day with the lowest temperature spread is found.
        /// </summary>
        [Test]
        public void TestWeatherWithCorrectInput()
        {
            string weatherFilePath = "../../../resources/BcxpChallenge/weather.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(_csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if the correct country with the highest population density is found.
        /// </summary>
        [Test]
        public void TestCountriesWithCorrectInput()
        {
            string countryFilePath = "../../../resources/BcxpChallenge/countries.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(_csvFileReader), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if empty weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithEmptyInput()
        {
            string weatherFilePath = "../../../resources/BcxpChallenge/empty.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(_csvFileReader), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if empty country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithEmptyInput()
        {
            string countryFilePath = "../../../resources/BcxpChallenge/empty.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(_csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidEntryInput()
        {
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidEntry.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(_csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidEntryInput()
        {
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidEntry.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(_csvFileReader), Is.EqualTo("Malta"));
        } 
        
        /// <summary>
        /// Test if completely invalid weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidInput()
        {
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalid.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(_csvFileReader), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if completely invalid country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidInput()
        {
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalid.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(_csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidTypesInput()
        {
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidType.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(_csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidTypesInput()
        {
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidType.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(_csvFileReader), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if a wrong weather input path is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithWrongPath()
        {
            Assert.That("wrongPath".FindHighestPopulationDensity(_csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if a wrong country input path is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithWrongPath()
        {
            Assert.That("wrongPath".FindHighestPopulationDensity(_csvFileReader), Is.EqualTo(null));
        }
    }
}