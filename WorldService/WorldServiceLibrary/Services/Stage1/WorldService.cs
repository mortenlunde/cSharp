using WorldClassLibrary.Models;
namespace WorldClassLibrary.Services.Stage1;

public class WorldService
{
    public IEnumerable<City> GetCities(Action<string>? logger = null)
    {
        // return [new City( 1,"Norway", "Vestfold","NOR", 5000000 )];
        return CityCsvFileService.GetCities("Files/City.csv", logger);
    }
}