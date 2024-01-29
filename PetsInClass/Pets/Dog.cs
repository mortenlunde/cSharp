namespace PetsInClass.Pets
{
    public class Dog : Pet
    {
        public Dog(string name) : base(name)
        {
            Noise = "bark";
            Trick = "loyal";
        }
    }
}