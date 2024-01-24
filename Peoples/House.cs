namespace Peoples;

public class House
{
    private string _address;

    public House(string address)
    {
        this._address = address;
    }

    public override string ToString()
    {
        return _address;
    }
}