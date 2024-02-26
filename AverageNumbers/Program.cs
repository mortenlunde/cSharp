List<int> nums = [2, 3, 2, 5, 3, 44, 34, 6, 7, 101, 10, 10, 10, 10];
Average(nums);
Median(nums);
Mode(nums);
Max((nums));
return;

void Average(IReadOnlyCollection<int> numbers)
{
    int sum = numbers.Sum();
    Console.WriteLine($"Average: {sum/numbers.Count}");
}

void Median(IReadOnlyList<int> numbers)
{
    int middle = (numbers.Count / 2) - 1;
    float median = numbers[middle];
    if (numbers.Count % 2 == 0)
    {
        median += numbers[middle + 1];
        median /= 2;
    }
    Console.WriteLine($"Median: {median}");
}

void Mode(IEnumerable<int> numbers)
{
    Dictionary<int, int> modeCalc = new Dictionary<int, int>();
    foreach (int number in numbers)
    {
        if (!modeCalc.TryAdd(number, 1))
        {
            modeCalc[number] += 1;
        }
    }
    int modeValue = modeCalc.MaxBy(pair => pair.Value).Key;
    int modeCount = modeCalc[modeValue];
    Console.WriteLine($"Most used number: {modeValue} - Count: {modeCount} times.");
}

void Max(IEnumerable<int> numbers)
{
    Console.WriteLine(numbers.Max());
    Console.WriteLine(numbers.Order().Last());
}