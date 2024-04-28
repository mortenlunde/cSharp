using WorldClassLibrary.Models;

namespace WorldClassLibrary.Services.Interfaces;

public interface IWorldService
{
    IEnumerable<City> GetCities(Func<City, bool>? searchFilter = default);
    IEnumerable<Country> GetCountries();
    IEnumerable<CountryLanguage> GetCountryLanguages();
}