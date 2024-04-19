using System.Globalization;
using WorldClassLibrary.Configuration;
using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;
using WorldClassLibrary.Utilities;

namespace WorldClassLibrary.Services.Stage2;

public class CountryCsvFileService(WorldServiceFileConfig config, Action<string> logger) : IIWorldDataService<Country>
{
    public IEnumerable<Country> GetData()
    {
        return GetCountries(config.CountryCsv!, logger);
    }

    private static IEnumerable<Country> GetCountries(string filename, Action<string>? logger = null)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException($"Finner ikke filen {filename}");

        IEnumerable<string[]> countryContents = CsvReader.ReadFromFile(filename);
        if (countryContents is null || !countryContents.Any())
        {
            logger?.Invoke($"Fant ingen data i filen {filename}");
            return Array.Empty<Country>();
        }

        List<Country> countries = [];
        foreach (string[] content in countryContents)
        {
            Country? country = Createcountry(content, logger);
            if (country is not null)
                countries.Add(country);
        }

        return countries;
    }

    // Code,Name,Continent,Region,SurfaceArea,Population,LocalName,Capital,GovernmentForm
    // ABW,Aruba,"North America",Caribbean,193.00,103000,Aruba,129,"Nonmetropolitan Territory of The Netherlands"
    private static Country? Createcountry(string[] content, Action<string>? logger)
    {
        if (content is [{ } strCode, { } strName, { } strContinent, { } strRegion, { } strSurfaceArea, { } strPopulation, { } strLocalName, { } strCapital, { } strGovernmentForm])
        {
            
            
            if (!double.TryParse(strSurfaceArea, CultureInfo.InvariantCulture, out double surfaceArea))
            {
                logger?.Invoke($"Feilet å konvertere decimal {strSurfaceArea} til string ({string.Join(',', content)})");
                return null;
            }
            if (!int.TryParse(strPopulation, out int Population))
            {
                logger?.Invoke($"Feilet å konvertere int {strPopulation} til string ({string.Join(',', content)})");
                return null;
            }
            
            return new Country( strCode,strName.Replace("\"", ""), strContinent.Replace("\"", ""), strRegion.Replace("\"", ""), surfaceArea, Population, strLocalName.Replace("\"", ""), strCapital, strGovernmentForm.Replace("\"", ""));
        }
        logger?.Invoke($"Forventet 9 elementer, men mottok bare {content.Length}.");
        return null;
    }
}