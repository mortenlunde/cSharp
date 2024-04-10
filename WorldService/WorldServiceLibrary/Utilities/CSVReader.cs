namespace WorldClassLibrary.Utilities;

public static class CsvReader
{
    public static IEnumerable<string[]> ReadFromFile(string filename)
    {
        List<string[]> csvList = [];

        if (!File.Exists(filename)) throw new FileNotFoundException($"Finner ikke filen {filename}");

        try
        {
            using StreamReader sr = new StreamReader(filename, System.Text.Encoding.UTF8);
            
            // Header
            string? unused = sr.ReadLine();
            
            // Lines
            while (!sr.EndOfStream)
            {
                string[]? line = sr.ReadLine()?.Split(",");
                if (line is not null)
                {
                    csvList.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            throw;
        }
        
        return csvList;
    }
}