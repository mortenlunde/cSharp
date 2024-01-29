namespace MyMath;

public class Square : Shape
{
    private readonly int _width;
    private readonly int _height;

    public Square(int width, int height)
    {
        this._width = width;
        this._height = height;
    }
}