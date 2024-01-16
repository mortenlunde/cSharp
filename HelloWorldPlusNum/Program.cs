namespace ConsoleApp3;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Add(35, 7));
        Console.WriteLine(Div(17, 3));
    }

    private static int Add(int num1, int num2)
    {
        Console.WriteLine($"Adding {num1} and {num2}");
        int solution = num1 + num2;
        return solution;
    }

    private static double Div(int num1, int num2)
    {
        double solution = num1 / (num2 * 1.0);
        return solution;
    }
}