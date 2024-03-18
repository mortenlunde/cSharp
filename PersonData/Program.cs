using PersonDataLibrary.Models;

Person a = new(firstName: "Morten", lastName: "Lunde", age: 33, gender: "Mann");
Person b = new()
{
    FirstName = "Morten",
    LastName = "lunde",
    Age = 18,
    Gender = "Mannemann"
};

Console.WriteLine(a);
Console.WriteLine(a.FirstName + " " + a.LastName + " " + a.Age + " " + a.Gender);
Console.WriteLine(b);