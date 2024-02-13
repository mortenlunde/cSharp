namespace Weather;

public delegate bool WeatherWarning(double temperature);

public static class Program
{
    private static bool FreezingWarning(double temperature)
    {
        return temperature <= 0;
    }
    private static bool SuperFreezingWarning(double temperature)
    {
        return temperature <= -20;
    }
    private static List<double> CheckTemperatures(List<double> temperatures, WeatherWarning warning)
    {
        return temperatures.Where(temp => warning(temp)).ToList();
    }

    private static void Main()
    {
        List<double> temperatures = [23, -23, -3, -2, 6, 11, 18];
        
        foreach (double temp in temperatures)
        {
            Console.WriteLine($"It is {temp} degrees");
        }
        List<double> freezingTemps = CheckTemperatures(temperatures, FreezingWarning);
        foreach (double temp in freezingTemps)
        {
            Console.WriteLine($"It is freezing: {temp}");
        }
        List<double> superfreezingTemps = CheckTemperatures(temperatures, SuperFreezingWarning);
        foreach (double temp in superfreezingTemps)
        {
            Console.WriteLine($"It is superfreezing: {temp}");
        }
    }
}