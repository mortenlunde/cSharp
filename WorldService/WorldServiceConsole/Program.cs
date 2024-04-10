using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Stage1;

Action<string> log = message => Console.WriteLine(message);
WorldService worldService = new();
foreach (City city in worldService.GetCities(log))
{
    Console.WriteLine(city);
}