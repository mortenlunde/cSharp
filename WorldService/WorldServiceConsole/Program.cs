using Microsoft.Extensions.Configuration;
using WorldClassLibrary.Configuration;
using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;
using WorldClassLibrary.Services.Stage2;
// using WorldService = WorldClassLibrary.Services.Stage1.WorldService;

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
    
#region Stage1
    // WorldService worldService = new();
    // foreach (City city in worldService.GetCities(log))
    // {
    //     Console.WriteLine(city);
    // }
#endregion
    
#region Stage2
    Action<string> log = Console.WriteLine;
    string connectionString = 
        config.GetValue<string>("ConnectionStrings:DefaultConnectionString")
        ?? throw new ArgumentNullException(string.Empty, "Missing connection string.");

    IWorldService worldService2 = new WorldService(
        new CityMySqlService(connectionString, log), 
        new CountryCsvFileService(worldServiceFileConfig, log), 
        new CountryLanguageCsvFileService(worldServiceFileConfig, log), 
        log);

    foreach (City city in worldService2.GetCities(c => c.Name.StartsWith("n", StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine(city);
    }

    foreach (Country country in worldService2.GetCountries())
    {
        Console.WriteLine(country);
    }
    
    foreach (CountryLanguage countryLanguage in worldService2.GetCountryLanguages())
    {
        Console.WriteLine(countryLanguage);
    }
#endregion