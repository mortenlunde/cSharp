// ReSharper disable PossibleLossOfFraction
namespace HelloWorld;

internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("hello world!!");
        try
        {
            Console.WriteLine(Div(2, 2));

            using StreamReader sr = new StreamReader("test.txt");

            while (sr.ReadLine() is { } line)
            {
                Console.WriteLine(line);
            }
        }
        catch (IOException ioe)
        {
            LogError($"{ioe.GetType().Name} ({ioe.Message})");
        }
        catch (Exception e)
        {
            LogError($"{e.GetType().Name} ({e.Message})");
        }

    }

    private static void LogError(string errorMessage)
    {
        const string logFilePath = "errorlog.txt";
        using StreamWriter srex = new(logFilePath, true);
        srex.WriteLine($"{DateTime.Now}: {errorMessage}");
    }
    private static double Div(int num1, int num2)
    {
        return num1/num2;
    }
}