namespace WorldClassLibrary.Models;


public enum IsOfficial
{
    T,
    F
}
public record CountryLanguage(string CountryCode, string Language, bool IsOfficial, double Percentage)
{
    
    
    public override string ToString()
    {
        return System.Text.Json.JsonSerializer.Serialize(this);
    }
}