namespace Wather2._0;

public static class Program
{
    private delegate bool Warning(double temperature, double humidity, ref string message);
    private static bool FreezingWarning(double temperature, double humidity, ref string message)
    {
        if (!(temperature <= 0)) return false;
        message = "--- Freezing warning!!! ---";
        return true;
    }

    private static bool RainWarning(double temperature, double humidity,ref string message)
    {
        if (!(humidity >= 50)) return false;
        message = "--- Rain warning!!! ---";
        return true;
    }

    private static void Main()
    {
        List<(double Temperature, double Humidity)> weatherConditions =
        [
            (20.0, 40.0),
            (10.0, 50.0),
            (20.0, 50.0),
            (-4, 15),
            (0, 10),
            (15, 75)
            
        ];
        weatherConditions.Add((20.0, 50.0));

        List<Warning> warnings =
        [
            FreezingWarning,
            RainWarning
        ];
        
        foreach ((double Temperature, double Humidity) condition in weatherConditions)
        {
            Console.WriteLine($"\nConditions \n" +
                              $"Temp:{condition.Temperature}\n" +
                              $"Humidity:{condition.Humidity}");
            foreach (Warning warning in warnings)
            {
                string message = "";
                if (warning(condition.Temperature, condition.Humidity, ref message))
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}