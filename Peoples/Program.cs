namespace Peoples
{
    internal static class Program
    {
        internal static void Main()
        {
            Person me = new Person("Morten", "Lunde");
            me.Update(new DateTime(1990, 10, 30));
            Console.WriteLine(me.GetName());
            Console.WriteLine(me.GetAge());
        }
    }
}