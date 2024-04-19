using MySqlConnector;
using SqlExample;

    const string DatabaseConnectionString = 
        "Server=lundeconsultno01.mysql.domeneshop.no;Database=lundeconsultno01;User=lundeconsultno01;Password=gove-6666-4111-megga";
const string SelectStatement = "SELECT * FROM Modeller";

MySqlConnection conn = new MySqlConnection(DatabaseConnectionString);
Console.WriteLine("Attempting to connect");
conn.Open();
Console.WriteLine($"Connect to {DatabaseConnectionString[0]}");
MySqlCommand sqlCommand = new MySqlCommand(SelectStatement, conn);
Console.WriteLine("Reading data");
MySqlDataReader reader = sqlCommand.ExecuteReader();
List<Modeller> biler = new List<Modeller>();

while (reader.Read())
{
    biler.Add(new Modeller()
    {
        ModellID  = (int)reader["ModellID"],
        MerkeID  = (int)reader["MerkeID"],
        Modell  = (string)reader["Modell"]
    });
}

Console.WriteLine("Read complete");
conn.Close();

foreach (Modeller modeller in biler)
{
    Console.WriteLine($"{modeller.ModellID} - {modeller.MerkeID} - {modeller.Modell}");
}