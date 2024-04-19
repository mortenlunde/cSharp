using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;

namespace WorldClassLibrary.Services.Stage2
{
    public class WorldService(
        IIWorldDataService<City> cityService,
        IIWorldDataService<Country> countryService,
        IIWorldDataService<CountryLanguage> countryLanguageService,
        Action<string> logger)
        : IIWorldService
    {
        private readonly Action<string> _logger = logger;

        public IEnumerable<City> GetCities()
        {
            return cityService.GetData();
        }

        public IEnumerable<Country> GetCountries()
        {
            return countryService.GetData();
        }

        public IEnumerable<CountryLanguage> GetCountryLanguages()
        {
            return countryLanguageService.GetData();
        }
    }
}
