namespace PetsInClass.Pets;

public class Pet
{
    private readonly string _name;
    protected string Noise = null!;
    protected string Trick = null!;

    protected Pet(string name)
    {
        this._name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetNoise()
    {
        return Noise;
    }

    public string GetTrick()
    {
        return Trick;
    }
}