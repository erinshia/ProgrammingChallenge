using BcxpChallenge;
using BcxpChallenge.CountryAnalysis;

namespace Tests.CountryAnalysis
{
    /// <summary>
    /// Provides tests for the CountryAnalyser class.
    /// </summary>
    public class CountryAnalyserTest
    {
        private CountryAnalyser _CountryAnalyser;

        /// <summary>
        /// Setting up the CountryAnalyser for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _CountryAnalyser = new CountryAnalyser();
        }

        /// <summary>
        /// Test if the method returns null when given null input.
        /// </summary>
        [Test]
        public void ParseCountryData_ReturnsNull_WhenGivenNullInput()
        {
            IEnumerable<string[]>? countryInput = null;
            var result = _CountryAnalyser.ParseCountryData(countryInput);
            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Test if the method returns null when given empty input.
        /// </summary>
        [Test]
        public void ParseCountryData_ReturnsNull_WhenGivenEmptyInput()
        {
            IEnumerable<string[]> countryInput = new List<string[]>();
            var result = _CountryAnalyser.ParseCountryData(countryInput);
            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Test if the method returns parsed country data when given valid input.
        /// </summary>
        [Test]
        public void ParseCountryData_ReturnsParsedData_WhenGivenValidInput()
        {
            IEnumerable<string[]> countryInput = new List<string[]>
            {
                new string[] { "CountryA", "CapitalA", "Founder", "1000", "1" },
                new string[] { "CountryB", "CapitalB", "Founder", "2000", "2" }
            };
            var result = _CountryAnalyser.ParseCountryData(countryInput);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Name, Is.EqualTo("CountryA"));
                Assert.That(result[1].Name, Is.EqualTo("CountryB"));
            });
        }

        /// <summary>
        /// Test if the country with the highest population is found when given valid data.
        /// </summary>
        [Test]
        public void FindCountryWithHighestPopulation_ReturnsCorrectCountry_WhenGivenValidData()
        {
            var countryData = new List<Country>
            {
                new Country("CountryA", 1000, 1),
                new Country("CountryB", 2000, 1)
            };
            var result = CountryAnalyser.FindCountryWithHighestPopulationDensity(countryData);
            Assert.That(result, Is.EqualTo("CountryB"));
        }

        /// <summary>
        /// Test if an empty string is returned when given an empty list.
        /// </summary>
        [Test]
        public void FindCountryWithHighestPopulation_ReturnsEmptyString_WhenGivenEmptyList()
        {
            var result = CountryAnalyser.FindCountryWithHighestPopulationDensity(new List<Country>());
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}