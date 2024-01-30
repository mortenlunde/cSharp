using MyMath;
namespace MathTester;

class Program
{
    static void Main()
    {
        List<Shape> shapes = [];

        shapes.Add(new Square(6, 7));
        shapes.Add(new Circle(3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }
        
    }
}