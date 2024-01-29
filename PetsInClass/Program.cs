using PetsInClass.Pets;

namespace PetsInClass
{
    internal static class Program
    {
        internal static void Main()
        {
            List<Pet> myPets =
            [
                new Cat("Fluffykins"),
                new Cat("Garfield")
            ];
            
            myPets.Add(new Dog("Pluto"));
            myPets.Add(new Dog("Rex"));
            
            myPets.Add(new Fish("Magicarp"));
            myPets.Add(new Fish("Gyarados"));
            

            foreach (Pet pet in myPets)
            {
                string pettype = pet.GetType().ToString().Substring(17);
                Console.WriteLine($"Pet named {pet.GetName()} if a {pettype} that makes a {pet.GetNoise()} noise and " +
                                  $"can {pet.GetTrick()}.");
            }
        }
    }
}