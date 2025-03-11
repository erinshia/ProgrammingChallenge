namespace BcxpChallenge
{
    /// <summary>
    /// NUnit tests to test the functionality of the App class.
    /// </summary>
    public class AppTest
    {
        /// <summary>
        /// Test the population density calculation.
        /// </summary>
        [Test]
        public void TestPopulationDensityCalculation()
        {
            Country testCountry = new Country("TestCountry", 10, 100);
            Assert.That(testCountry.CalculatePopulationDensity(), Is.EqualTo(0.1f));
        }
        
        /// <summary>
        /// Test the temperature spread calculation.
        /// </summary>
        [Test]
        public void TestTemperatureSpreadCalculation()
        {
            Weather testWeather = new Weather(1, 10, -5);
            Assert.That(testWeather.CalculateTemperatureSpread(), Is.EqualTo(15));
        }
        
        /// <summary>
        /// Test if the correct day with the lowest temperature spread is found.
        /// </summary>
        [Test]
        public void TestWeatherWithCorrectInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string weatherFilePath = "../../../resources/BcxpChallenge/weather.csv";
            Assert.That(App.HandleWeatherData(csvFileParser, weatherFilePath), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if the correct country with the highest population density is found.
        /// </summary>
        [Test]
        public void TestCountriesWithCorrectInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string countryFilePath = "../../../resources/BcxpChallenge/countries.csv";
            Assert.That(App.HandleCountryData(csvFileParser, countryFilePath), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if empty weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithEmptyInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string weatherFilePath = "../../../resources/BcxpChallenge/Empty.csv";
            Assert.That(App.HandleWeatherData(csvFileParser, weatherFilePath), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if empty country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithEmptyInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string countryFilePath = "../../../resources/BcxpChallenge/Empty.csv";
            Assert.That(App.HandleCountryData(csvFileParser, countryFilePath), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidEntryInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidEntry.csv";
            Assert.That(App.HandleWeatherData(csvFileParser, weatherFilePath), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with an invalid line is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidEntryInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidEntry.csv";
            Assert.That(App.HandleCountryData(csvFileParser, countryFilePath), Is.EqualTo("Malta"));
        } 
        
        /// <summary>
        /// Test if completely invalid weather input is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalid.csv";
            Assert.That(App.HandleWeatherData(csvFileParser, weatherFilePath), Is.EqualTo(0));
        }
        
        /// <summary>
        /// Test if completely invalid country input is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalid.csv";
            Assert.That(App.HandleCountryData(csvFileParser, countryFilePath), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if weather input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithInvalidTypesInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string weatherFilePath = "../../../resources/BcxpChallenge/weatherInvalidType.csv";
            Assert.That(App.HandleWeatherData(csvFileParser, weatherFilePath), Is.EqualTo(14));
        }
        
        /// <summary>
        /// Test if country input with incorrect types is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithInvalidTypesInput()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            string countryFilePath = "../../../resources/BcxpChallenge/countriesInvalidType.csv";
            Assert.That(App.HandleCountryData(csvFileParser, countryFilePath), Is.EqualTo("Malta"));
        }
        
        /// <summary>
        /// Test if a wrong weather input path is handled correctly.
        /// </summary>
        [Test]
        public void TestWeatherWithWrongPath()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            Assert.That(App.HandleCountryData(csvFileParser, "wrongPath"), Is.EqualTo(null));
        }
        
        /// <summary>
        /// Test if a wrong country input path is handled correctly.
        /// </summary>
        [Test]
        public void TestCountriesWithWrongPath()
        {
            CsvFileParser csvFileParser = new CsvFileParser();
            Assert.That(App.HandleCountryData(csvFileParser, "wrongPath"), Is.EqualTo(null));
        }
    }
}