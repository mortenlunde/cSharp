using MyMath;
namespace MathTester;

internal static class Program
{
    internal static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        Square sq = new Square(6, 7);
        Console.WriteLine(sq.Area());
        
        shapes.Add(new Square(6, 7));
        shapes.Add(new Radius(7));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.ToString());
        }
    }
}