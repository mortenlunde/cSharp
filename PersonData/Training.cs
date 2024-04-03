namespace PersonData;

public class Training
{
    public static List<int> FilterNumberGreaterThan10(List<int> numbers)
    {
        return numbers.Where(x => x > 10).ToList();
    }
    
}