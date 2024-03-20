using Microsoft.Extensions.Configuration;
using PersonDataLibrary.Models;
using PersonDataLibrary.Services;
#pragma warning disable CS0162 // Unreachable code detected
// ReSharper disable HeuristicUnreachableCode

//Configuration
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsetings.json")
    .Build();
string filename = configuration["PersonCSVFileName"] ?? throw new ArgumentException("Mangler filnavn fra konfigurasjon.");

goto csvread;

// Signatur på konstruktur
Person a = new(firstName: "Morten", lastName: "Lunde", age: 33, gender: "Mann");
Person b = new()
{
    FirstName = "Morten",
    LastName = "lunde",
    Age = 18,
    Gender = "Mannemann"
};

// Opprette instans/objekt

Console.WriteLine(a);
Console.WriteLine(a.FirstName + " " + a.LastName + " " + a.Age + " " + a.Gender);
Console.WriteLine(b);

csvread:
IEnumerable<Person> persons = PersonDataService.GetPersons(filename);
foreach (Person person in persons)
{
    Console.WriteLine(person);
}