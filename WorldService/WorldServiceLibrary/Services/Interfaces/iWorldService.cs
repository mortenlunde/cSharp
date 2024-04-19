using WorldClassLibrary.Models;

namespace WorldClassLibrary.Services.Interfaces;

public interface IIWorldService
{
    IEnumerable<City> GetCities();
    IEnumerable<Country> GetCountries();
    IEnumerable<CountryLanguage> GetCountryLanguages();
}