using WorldClassLibrary.Models;

namespace WorldClassLibrary.Services.Interfaces;

public interface IICityService
{
    IEnumerable<City> GetCities();
}