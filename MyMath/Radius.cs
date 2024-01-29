namespace MyMath;

public class Radius(double radius):Shape
{
    public new double Area()
    {
        return Math.PI * radius * radius;
    }
}