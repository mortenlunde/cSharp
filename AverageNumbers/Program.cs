List<int> nums = [2, 3, 2, 5, 3, 44, 34, 6, 7, 10];
Average(nums);
Median(nums);
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