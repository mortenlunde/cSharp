namespace TextDecoratorInClass;

internal static class Program
{
    internal static void Main(string[] args)
    {
        if (args.Length <= 1 || args[0].ToLower() == "help")
        {
            ShowHelp();
            return;
        }
        
        switch (args[0].ToLower())
        {
            case "b":
            case "#":
                BlockMode(args);
                break;
            case "alt":
                AltMode(args);
                break;
            case "pig":
                PigLatin(args);
                break;
            default:
                ShowHelp();
                break;
        }
    }

    private static void PigLatin(string[] args)
    {
        string[] input = args.Skip(1).ToArray();
        foreach (string word in input)
        {
            Console.Write(Piggify(word) + " ");
        }

        Console.Write("\n");
    }

    private static string Piggify(string word)
    {
        char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u'};
        if (vowels.Contains(word[0]))
        {
            return word + "yay";
        }
        
        vowels = ['a', 'e', 'i', 'o', 'u', 'y'];
        string outputStart = "";
        string outputEnd = "";
        string ultimateEnd = "ay";
        char? punct = null;

        bool begin = true;
        bool containsUpper = false;
        foreach (char c in word)
        {
            if (vowels.Contains(Char.ToLower(c)))
            {
                begin = false;
            }

            if (!containsUpper && char.IsUpper(c))
            {
                containsUpper = true;
            }
            
            if (char.IsPunctuation(c))
            {
                punct = c;
                break;
            }
            
            if (begin)
            {
                outputEnd += Char.ToLower(c);
            }
            else
            {
                outputStart += Char.ToLower(c);
            }
        }

        if (containsUpper)
        {
            string newfront = "";
            for (int i = 0; i < outputStart.Length; i++)
            {
                if (i == 0)
                {
                    
                    newfront += Char.ToUpper(outputStart[i]);
                }
                else
                {
                    newfront += outputStart[i];
                }
            }

            outputStart = newfront;
        }

        if (punct != null)
        {
            ultimateEnd += punct;
        }

        return outputStart + outputEnd + ultimateEnd;
    }

    private static void AltMode(string[] args)
    {
        string message = ArgsToString(args);

        bool caps = false;
        foreach (char c in message)
        {
            char output = caps ? Char.ToUpper(c) : Char.ToLower(c);
            
            caps = !caps;
            Console.Write(output);
        }
        Console.Write("\n");
    }

    private static void BlockMode(string[] args)
    {
        string message = ArgsToString(args);

        for (int i = 0; i < message.Length +4; i++)
        {
            Console.Write("#");
        }
        Console.WriteLine( "\n# " + message + " #" );
        for (int i = 0; i < message.Length +4; i++)
        {
            Console.Write("#");
        }
        Console.WriteLine("");
    }

    static string ArgsToString(String[] args)
    {
        string[] messageArray = args.Skip(1).ToArray();
        string message = "";
        foreach (string word in messageArray)
        {
            message += word + " ";
        }
        return message.Trim();
    }

    private static void ShowHelp()
    {
        Console.WriteLine("This is help!");
        Console.WriteLine("You must provide at least 2 arguments");
        Console.WriteLine("use B for clock mode");
        Console.WriteLine("use alt for alternating capitalization");
        Console.WriteLine("use pig for pig latin");
    }
}