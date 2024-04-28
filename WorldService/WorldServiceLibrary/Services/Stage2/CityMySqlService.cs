using MySql.Data.MySqlClient;
using WorldClassLibrary.Models;
using WorldClassLibrary.Services.Interfaces;

namespace WorldClassLibrary.Services.Stage2;

public class CityMySqlService : IIWorldDataService<City>
{
    private readonly string _connectionString;
    private readonly Action<string> _log;
    
    public CityMySqlService(string connectionString, Action<string> log)
    {
        _connectionString = connectionString;
        _log = log;
    }
    public IEnumerable<City> GetData()
    {
        try
        {
            var cities = new List<City>();
            using MySqlConnection conn = new(_connectionString);
            conn.Open();
            MySqlCommand cmd = new("SELECT Id, Name, CountryCode, District, Population FROM world.city", conn);

            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                City city = new City
                (
                    reader.GetInt32("ID"),
                    reader.GetString("Name"), 
                    reader.GetString("CountryCode"),
                    reader.GetString("District"),
                    reader.GetInt32("Population")
                        
            );
                cities.Add(city);
            }

            return cities;
        }
        catch (Exception e)
        {
            _log.Invoke(e.Message);
            return Enumerable.Empty<City>();
        }
    }
    
}