using System.Text.Encodings.Web;
using System.Text.Json;

namespace WorldClassLibrary.Models;

public record Country(string Code, string Name, string Continent, string Region, double SurfaceArea, int Population, string LocalName, string Capital, string GovernmentForm)
{
    public string ToJson()
    {
        Country WithRegion(string region) => this with { Region = region.Trim('"') };
        JsonSerializerOptions options = new();
        options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        options.WriteIndented = false;
        // Optional: Format the JSON for readability

        return JsonSerializer.Serialize(this, options);
    }
    public override string ToString()
    {
        return ToJson();
    }
}