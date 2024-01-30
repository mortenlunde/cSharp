namespace MyMath;

public class Circle:Shape
{
    private double _radius;

    public double Radius
    {
        get => _radius;
        set => _radius = value;
    }

    public Circle(double radius)
    {
        this._radius = radius;
    }

    
    /// <summary>
    /// Returns the area of the circle
    /// </summary>
    /// <returns>Area</returns>
    public override double Area()
    {
        return Math.PI * _radius * _radius;
    }
}