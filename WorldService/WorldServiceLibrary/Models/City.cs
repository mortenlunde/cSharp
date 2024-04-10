namespace WorldClassLibrary.Models;

public record City(int Id, string Name, string CountryCode, string District, int Population)
{
    public override string ToString()
    {
        return System.Text.Json.JsonSerializer.Serialize(this);
    }
}