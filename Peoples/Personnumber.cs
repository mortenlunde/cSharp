namespace Peoples;

public class Personnumber
{
    private int _personNumber;

    public Personnumber(int personNumber)
    {
        _personNumber = personNumber;
    }

    public int Number
    {
        get => _personNumber;
        set => _personNumber = value;
    }
}