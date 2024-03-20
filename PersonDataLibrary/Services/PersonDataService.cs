using PersonDataLibrary.Models;
using PersonDataLibrary.Utilities;

namespace PersonDataLibrary.Services;

public class PersonDataService
{
    public static IEnumerable<Person> GetPersons(string filename)
    {
        // var persons = new List<Person>();
        List<Person> persons = [];
        
        // Lese fra fil. csv -> List<string[]>
        IEnumerable<string[]> personsData = CsvReader.ReadFromFile(filename);
        
        // Tolke innhold -> string --> person
        foreach (string[] personDataArr in personsData)
        {
            // Opprette person
            // List pattern matching
            if (personDataArr is not [{ } fname, { } lname, { } agestr, { } gndr]) continue;
            if (int.TryParse(agestr, out int age))
            {
                persons.Add(new Person(fname, lname, age, gndr));
            }
            else
            {
                Console.WriteLine($"Klarte ikke å konvertere {agestr} som heltall.");
            }
        }

        return persons;
    }
}