namespace Generics1;

internal static class Program
{
    internal static void Main()
    {
        List<string> names =
        [
            "Line",
            "Morten",
            "Alex"
        ];

        List<int> grades =
        [
            99,
            98,
            50
        ];

        grades.Sort();
        names.Sort();
        
        Print(names);
        Print(grades);
    }

    private static void Print<T>(List<T> list)
    {
        foreach (T item in list)
        {
            if (item != null) Console.WriteLine(item.ToString());
        }
    }
}