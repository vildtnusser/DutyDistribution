using System.Runtime;
using Npgsql;

namespace DutyDistribution.Components.Shared;

public class DataBase
{
    private static NpgsqlConnection _connection = null;

    public static NpgsqlConnection getConnection()
    {
        if (_connection is null)
        {
            _connection = new NpgsqlConnection("Host=127.0.0.1;Database=DutyDistribution;User Id=postgres;Password=admin;");
            _connection.Open();
            
        }
        return _connection;

    }
}