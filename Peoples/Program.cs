namespace Peoples
{
    internal static class Program
    {
        internal static void Main()
        {
            Person me = new Person("Morten Lunde", 301090123);
            me.Update(new DateTime(1990, 10, 30));
            me.SetAddress(new House("Rødsåsveien 10c, 3176 Undrumsdal"));
            
            Console.WriteLine(me.GetName());
            Console.WriteLine(me.GetAge());
            Console.WriteLine(me.GetAddress());
        }
    }
}