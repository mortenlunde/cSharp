namespace AgeChecker;

internal class Program
{
    private static void Main()
    {
        Console.Write("Skriv inn din alder: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int alder))
        {
            if (alder >= 14) Console.WriteLine("Du er gammel nok til å kjøpe energidrikk.");
            if (alder >= 18) Console.WriteLine("Du er gammel nok til å kjøpe øl.");
            if (alder >= 20) Console.WriteLine("Du er gammel nok til å kjøpe sprit.");
            if (alder >= 21) Console.WriteLine("Du er gammel nok til å kjøpe øl i USA.");
            if (alder < 14) Console.WriteLine("Du er ikke gammel nok til å kjøpe noe.");
        }
        else
        {
            Console.WriteLine("Ugyldig inntasting. Vennligst skriv inn et heltall.");
        }
    }
}