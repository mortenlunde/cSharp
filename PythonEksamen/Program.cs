namespace PythonEksamen
{
    internal static class Program
    {
        private static void Main()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "solgtevarer.csv");

            string sVarer = ReadFile(filePath);
            Console.WriteLine(sVarer);
        }
        
        private static string ReadFile(string filePath)
        {
            string varer = "";
            string[] solgteVarer = File.ReadAllLines(filePath);

            foreach (string s in solgteVarer)
            {
                varer += $"{s}";
            }
            
            return varer;
        }
    }
}