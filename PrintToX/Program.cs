namespace PrintToX;

internal static class Program
{
    private delegate void PrintMethod(string text);
    private static void Main()
    {
        PrintMethod chosenOne = text => Console.WriteLine(" 🍎: " + text);
        Action<string> thingToDo = (text) => Console.WriteLine("🌶️: " + text);
        PrintMethod one = chosenOne;
        Action bigAction = () =>
        {
            Console.WriteLine(" 🍤: U shrimp!");
            Console.WriteLine(" 🧇: Blue waffle");
            one.Invoke("Well look at this then..");
        };
        
        chosenOne.Invoke("Hello Apple!");
        thingToDo.Invoke("This was spicy!");
        bigAction.Invoke();

        chosenOne = PrintToScreen;
        chosenOne("Testing 2 screen");
        
        chosenOne = PrintToPaper;
        chosenOne("Testing 2 paper");
    }

    private static void PrintToScreen(string text)
    {
        Console.WriteLine("🖥️: " + text);
    }

    private static void PrintToPaper(string text)
    {
        Console.WriteLine("🖨️: " + text);
    }
}