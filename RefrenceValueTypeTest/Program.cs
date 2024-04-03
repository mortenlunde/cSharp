using Dumpify;
using RefrenceValueTypeTest;

Person person = new() { Age = 20, Name = "Morten" };
InitInt(out int age);

age.Dump();
person.Dump();

IncreaseInt(ref age);
IncreaseAge(person);

age.Dump();
person.Dump();

static void IncreaseAge(Person person)
{
    person.Age += 1;
}

static void IncreaseInt(ref int x)
{
    x++;
}

static void InitInt(out int x)
{
    x = 10;
}