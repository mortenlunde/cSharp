namespace FizzBuzz;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine(" Fizz Buzz ");
        Console.WriteLine("-----------");

        for (int i = 1; i <= 100; i++)
        {
            Console.Write(i + " ");
            if (i % 3 == 0) Console.Write("Fizz");
            if (i % 5 == 0) Console.Write("Buzz");
            Console.Write("\n");
        }
    }
}