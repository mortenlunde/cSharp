using WorldClassLibrary.Models;
using WorldClassLibrary.Utilities;

namespace WorldClassLibrary.Services.Stage1;

public static class CityCsvFileService
{
    public static IEnumerable<City> GetCities(string filename, Action<string>? logger = null)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException($"Finner ikke filen {filename}");

        IEnumerable<string[]> cityContents = CsvReader.ReadFromFile(filename);
        if (cityContents is null || !cityContents.Any())
        {
            logger?.Invoke($"Fant ingen data i filen {filename}");
            return Array.Empty<City>();
        }

        List<City> cities = [];
        foreach (string[] content in cityContents)
        {
            City? city = CreateCity(content, logger);
            if (city is not null)
                cities.Add(city);
        }

        return cities;
    }

    private static City? CreateCity(string[] content, Action<string>? logger)
    {
        if (content is [string strID, string strName, string strCC, string strDis, string strPop])
        {
            if (!int.TryParse(strID, out int id))
            {
                logger?.Invoke($"Feilet å konvertere int {strID} til string ({string.Join(',', content)}");
                return null;
            }
            if (string.IsNullOrEmpty(strName))
            {
                logger?.Invoke($"Navn kan ikke være null ({string.Join(',', content)}");
                return null;
            }
            
            if (string.IsNullOrEmpty(strCC))
            {
                logger?.Invoke($"CountryCode kan ikke være null ({string.Join(',', content)}");
                return null;
            }
            
            if (string.IsNullOrEmpty(strDis))
            {
                logger?.Invoke($"District kan ikke være null ({string.Join(',', content)}");
                return null;
            }
            
            if (!int.TryParse(strPop, out int pop))
            {
                logger?.Invoke($"Feilet å konvertere int {strPop} til string ({string.Join(',', content)}");
                return null;
            }

            if (string.IsNullOrEmpty(strPop))
            {
                logger?.Invoke($"Population kan ikke være null ({string.Join(',', content)}");
                return null;
            }

            return new City(id, strName, strCC, strDis, pop);
        }
        logger?.Invoke($"Forventet 5 elementer, men mottk bare {content.Length}.");
        return null;
    }
}