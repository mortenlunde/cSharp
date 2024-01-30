namespace MyMath;

public class Square:Shape
{
    public double Width;
    public double Height;

    //"ctorf" then press tab
    public Square(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }
    
    
}