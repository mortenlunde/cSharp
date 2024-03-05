namespace FilterExample;

public class Result(string name, float grade)
{
    public readonly string Name = name;
    public readonly float Grade = grade;
}

public class GradingTool
{
    private delegate bool FilterDelegate(float value);

    public void ExecuteOrder()
    {
        List<Result> gradesList =
        [
            new Result("Steeve", 99),
            new Result("Stevo", 89),
            new Result("Stevus", 79),
            new Result("Steph", 69),
            new Result("Steever", 59),
            new Result("Robert (pronounced \"Steve\")", 49),
            new Result("Esteveabeth", 39),
            new Result("Mari", 29),
            new Result("Evev", 19),
            new Result("Eve", 9),
            new Result("Eveee", 66),
            new Result("Lina", 80),
            new Result("Alex", 75)
        ];


        FilterDelegate filterOver70 = FilterMaker(70);
        PrintGrade(FilterResults(gradesList, filterOver70));
    }

    private FilterDelegate FilterMaker(float value)
    {
        return input => input > value;
    }

    private List<Result> FilterResults(List<Result> results, FilterDelegate filter)
    {
        List<Result> output = [];
        output.AddRange(results.Where(r => filter(r.Grade)));
        return output;
    }

    private void PrintGrade(List<Result> results)
    {
        foreach (Result r in results)
        {
            Console.WriteLine($"{r.Name} => {r.Grade} ");
        }
    }
}