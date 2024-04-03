using PersonDataLibrary.Models;
namespace PersonDataLibrary.Utilities;

public class JSONReader
{
    public static IEnumerable<T> ReadFromFile<T>(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException($"Finner ikke filen {filename}");

        List<T> items = new List<T>();
        using StreamReader reader = new StreamReader(filename, System.Text.Encoding.UTF8);

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (line is null) break;

            var person = System.Text.Json.JsonSerializer.Deserialize<T>(line);
            if (person is not null) items.Add(person);
        }

        return items;
    }
}