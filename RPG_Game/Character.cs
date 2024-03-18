namespace RPG_Game;

public enum Direction
{
    North,
    East,
    South,
    West
};

public class Position
{
    public int X;
    public int Y;
}

public abstract class Character
{
    public int Health;
    public Position Position;

    public void Move(Direction move)
    {
        
    }
}