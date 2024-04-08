const int number = 42;

Console.WriteLine($"Given {number} - factor(s) are:");
foreach (int i in Finder(number))
{
    Console.WriteLine($"{i} is a factor");
}

List<int> Finder(int num)
{
    List<int> factors = [];
    List<int> usedFactors = [];
    for (int i = 2; i <= num; i++)
    {
        foreach (int unused in usedFactors.Where(usedFactor => i % usedFactor == 0))
        {
            goto skip;
        }
        if (num % i == 0)
        {
            factors.Add(i);
            
            usedFactors.Add(i);
        }
        
        
        skip: ;
    }

    return factors;
}