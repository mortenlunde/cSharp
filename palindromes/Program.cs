namespace palindromes;

internal static class Program
{
    private static void Main()
    {
        List<string> palindromes = ["tenet", "racecar", "Never odd or even", "test"];

        foreach (string palindrome in palindromes)
        {
            Console.Write($"{palindrome}: ");
            Console.Write(CheckIfPalindrome(palindrome) ? " is a palindrome.\n" : " is not a palindrome.\n");
        }
    }
    private static bool CheckIfPalindrome(string candidate)
    {
        string lower = candidate.ToLower().Replace(" ", "");
    
        for (int i = 0; i < Math.Ceiling(lower.Length / 2.0); i++)
        {
            if (lower[i] != lower[lower.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}