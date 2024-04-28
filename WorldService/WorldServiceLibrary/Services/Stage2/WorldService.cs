using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;

namespace WorldClassLibrary.Services.Stage2
{
    public class WorldService(
        IIWorldDataService<City> cityService,
        IIWorldDataService<Country> countryService,
        IIWorldDataService<CountryLanguage> countryLanguageService,
        Action<string> logger)
        : IWorldService
    {
        private readonly Action<string> _logger = logger;

        public IEnumerable<City> GetCities(Func<City, bool>? searchFilter = default)
        {
            Func<City, bool>? search = (searchFilter is not null) ? searchFilter : _ => true;
            return cityService.GetData().Where(search);
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
