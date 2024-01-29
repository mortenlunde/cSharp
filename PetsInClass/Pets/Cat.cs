namespace PetsInClass.Pets
{
    public class Cat : Pet
    {
        public Cat(string name) : base(name)
        {
            Noise = "meow";
            Trick = "rule the world";
        }
    }
}