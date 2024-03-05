namespace Lamda;

internal static class Program
{
    private delegate int Op(int x, int y);

    private delegate void Thing();
    private static int Add(int x, int y)
    {
        return x + y;
    }
    
    private static int Sub(int x, int y)
    {
        return x - y;
    }
    internal static void Main()
    {
        Op? opToForm = null;
        char input = 'a';
        int num = 0;

        opToForm = input switch
        {
            'a' => Add,
            's' => Sub,
            _ => opToForm
        };
        
        if (opToForm != null) num = opToForm(35, 7);
        Console.WriteLine(num);
        List<Op> steps =
        [
            Add,
            Sub,
            Add
        ];
        foreach (Op p in steps)
        {
            p.Invoke(3, 3);
        }

        Thing doMe = Console.WriteLine;
    }
}