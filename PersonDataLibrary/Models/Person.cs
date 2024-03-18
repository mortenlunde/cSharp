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

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? Gender { get; set; }

    public override string ToString()
    {
        return FirstName + " " + LastName + " " + Age + " " + Gender;
    }
}