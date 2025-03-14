using BcxpChallenge.FileParser;

namespace BcxpChallenge
{
    /// <summary>
    /// NUnit tests to test the functionality of the programm.
    /// </summary>
    public class AppTest
    {
        /// <summary>
        /// Test if the correct day with the lowest temperature spread is found.
        /// </summary>
        [Test]
        public void TestWeatherWithCorrectInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string weatherFilePath = "../../../resources/BcxpChallenge/weather.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if the correct country with the highest population density is found.
        /// </summary>
        [Test]
        public void TestCountriesWithCorrectInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string countryFilePath = "../../../resources/BcxpChallenge/countries.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(csvFileReader), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if empty weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithEmptyInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string weatherFilePath = "../../../resources/BcxpChallenge/Empty.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(csvFileReader), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if empty country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithEmptyInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string countryFilePath = "../../../resources/BcxpChallenge/Empty.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidEntryInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidEntry.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidEntryInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidEntry.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(csvFileReader), Is.EqualTo("Malta"));
        } 
        
        /// <summary>
        /// Test if completely invalid weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalid.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(csvFileReader), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if completely invalid country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalid.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidTypesInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidType.csv";
            Assert.That(weatherFilePath.FindLowestTempSpread(csvFileReader), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidTypesInput()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidType.csv";
            Assert.That(countryFilePath.FindHighestPopulationDensity(csvFileReader), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if a wrong weather input path is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithWrongPath()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            Assert.That("wrongPath".FindHighestPopulationDensity(csvFileReader), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if a wrong country input path is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithWrongPath()
        {
            CsvFileReader csvFileReader = new CsvFileReader();
            Assert.That("wrongPath".FindHighestPopulationDensity(csvFileReader), Is.EqualTo(null));
        }
    }
}