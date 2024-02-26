namespace Class26._02._24;

internal static class Program
{
    internal static void Main()
    {
        string words = "Hello, World!";

        char[] wordsArray = words.ToCharArray();
        string output = "";
            
        for (int i = wordsArray.Length - 1; i >= 0; i--)
        {
            output += wordsArray[i];
        }
            
        Console.WriteLine(output);
    }
}