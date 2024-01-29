using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GamesApp
{
    internal static class Program
    {
        internal static void Main()
        {
            Console.WriteLine(File.Exists("games.json") ? "File exsists!" : "No file found...");
            
            // Open a file using stream reader
            StreamReader sr = new StreamReader("games.json");
            // Handle the file contents using json text reader
            JsonTextReader jtr = new JsonTextReader(sr);
            // Convert to JObject through JToken
            JObject jo = (JObject)JToken.ReadFrom(jtr);

            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(jo["games"].ToString());
        }
    }
}