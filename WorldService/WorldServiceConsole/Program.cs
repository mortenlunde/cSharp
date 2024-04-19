using Microsoft.Extensions.Configuration;
using WorldClassLibrary.Configuration;
using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;
using WorldClassLibrary.Services.Stage2;
using WorldService = WorldClassLibrary.Services.Stage1.WorldService;

#region Configuration
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    WorldServiceFileConfig? worldServiceFileConfig = config
        .GetSection(nameof(WorldServiceFileConfig))
        .Get<WorldServiceFileConfig>();

    if (worldServiceFileConfig is null)
        throw new ArgumentNullException(nameof(worldServiceFileConfig));
    if (!worldServiceFileConfig.IsValid)
        throw new ArgumentException();
#endregion

Action<string> log = Console.WriteLine;
goto stage2;
#region Stage1
    WorldService worldService = new();
    foreach (City city in worldService.GetCities(log))
    {
        Console.WriteLine(city);
    }
#endregion

stage2:
#region Stage2
    IIWorldService iWorldService = new WorldClassLibrary.Services.Stage2.WorldService(
        new CityCsvFileService(worldServiceFileConfig, log), 
        new CountryCsvFileService(worldServiceFileConfig, log), 
        new CountryLanguageCsvFileService(worldServiceFileConfig, log), 
        log);

    foreach (City city in iWorldService.GetCities())
    {
        Console.WriteLine(city);
    }

    foreach (Country country in iWorldService.GetCountries())
    {
        Console.WriteLine(country);
    }

    foreach (CountryLanguage countryLanguage in iWorldService.GetCountryLanguages())
    {
        Console.WriteLine(countryLanguage);
    }
#endregion