namespace CreditcardChecker
{
    internal static class Program
    {
        private static void Main()
        {
            const string name = "Morten Lunde";
            Console.WriteLine($"Luhnchecker/creditcard-control by {name}");
            
            string filePath = Path.Combine(Environment.CurrentDirectory, "luhn_numbers.txt");
            
            if (File.Exists(filePath))
            {
                string creditCards = ReadFile(filePath);
                Console.WriteLine(creditCards);
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
        }

        private static string ReadFile(string filePath)
        {
            try
            {
                string[] cards = File.ReadAllLines(filePath);
                string result = "";

                foreach (string card in cards)
                {
                    if (card.Length == 20)
                    {
                        int[] digits = card.Select(c => int.Parse(c.ToString())).ToArray();
                        bool isValid = CheckNumber(digits);
                        string validOrNot = isValid ? "Valid." : "Invalid.";
                        result += $"{card}: {validOrNot}\n";
                    }
                    else
                    {
                        result += $"{card}: Invalid format for card.\n";
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
            
        }

        private static bool CheckNumber(int[] digits)
        {
            int sum = 0;
            bool doubleDigit = false;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = doubleDigit ? digits[i] * 2 : digits[i];
                sum += digit > 9 ? digit - 9 : digit;
                doubleDigit = !doubleDigit;
            }

            return sum % 10 == 0;
        }
    }
}