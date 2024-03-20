namespace PersonDataLibrary.Models;

public class Person
{
    public Person()
    {
    }
    
    public Person(string firstName, string lastName, int age, string gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
    }

    public string? FirstName { get; init; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? Gender { get; set; } = string.Empty;

    public override string ToString()
    {
        return FirstName + " " + LastName + " " + Age + " " + Gender;
    }
}