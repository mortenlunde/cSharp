namespace WorldClassLibrary.Configuration;

public class WorldServiceFileConfig
{
    public required string CityCsv { get; init; }
    public required string CountryCsv { get; init; }
    public required string CountryLanguageCsv { get; init; }

    public bool IsValid =>
        !(string.IsNullOrEmpty(CityCsv) || string.IsNullOrEmpty(CountryCsv) || string.IsNullOrEmpty(CountryLanguageCsv))
        && (File.Exists(CityCsv) && File.Exists(CountryCsv) && File.Exists(CountryLanguageCsv));
}