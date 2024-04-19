using System.Globalization;
using WorldClassLibrary.Configuration;
using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;
using WorldClassLibrary.Utilities;

namespace WorldClassLibrary.Services.Stage2;

public class CountryLanguageCsvFileService(WorldServiceFileConfig config, Action<string> logger)
    : IIWorldDataService<CountryLanguage>
{
    public IEnumerable<CountryLanguage> GetData()
    {
        return GetCountryLanguages(config.CountryLanguageCsv!, logger);
    }

    private static IEnumerable<CountryLanguage> GetCountryLanguages(string filename, Action<string>? logger = null)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException($"Finner ikke filen {filename}");

        IEnumerable<string[]> CountryLanguageContents = CsvReader.ReadFromFile(filename);
        if (CountryLanguageContents is null || !CountryLanguageContents.Any())
        {
            logger?.Invoke($"Fant ingen data i filen {filename}");
            return Array.Empty<CountryLanguage>();
        }

        List<CountryLanguage> countryLanguages = [];
        foreach (string[] content in CountryLanguageContents)
        {
            CountryLanguage? countryLanguage = CreateCountryLanguage(content, logger);
            if (countryLanguage is not null)
                countryLanguages.Add(countryLanguage);
        }

        return countryLanguages;
    }

    // CountryCode,Language,IsOfficial,Percentage
    // ABW,Dutch,T,5.3
    private static CountryLanguage? CreateCountryLanguage(string[] content, Action<string>? logger)
    {
        if (content is [{ } strCountryCode, { } strLanguage, { } strIsOfficial, { } strPercentage])
        {
            if (!Enum.TryParse(strIsOfficial, out IsOfficial isOfficial))
            {
                logger?.Invoke($"Feilet å konvertere enum {isOfficial} til string ({string.Join(',', content)})");
                return null;
            }
            if (!double.TryParse(strPercentage, CultureInfo.InvariantCulture, out double percentage))
            {
                logger?.Invoke($"Feilet å konvertere double til string '{strPercentage}' in line: {string.Join(',', content)}");
                return null;
            }
            
            bool isOfficialBool = isOfficial switch
            {
                IsOfficial.T => true,
                IsOfficial.F => false,
                _ => throw new ArgumentException($"Invalid IsOfficial value '{strIsOfficial}'"),
            };
            return new CountryLanguage(strCountryCode, strLanguage, isOfficialBool, percentage);
        }
        logger?.Invoke($"Forventet 4 elementer, men mottok bare {content.Length}.");
        return null;
    }
}