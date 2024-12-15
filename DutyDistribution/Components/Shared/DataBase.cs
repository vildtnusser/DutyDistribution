using System.Runtime;
using Npgsql;

namespace DutyDistribution.Components.Shared;

public class DataBase
{
    private static NpgsqlConnection? _connection;

    public static NpgsqlConnection GetConnection()
    {
        if (_connection is null)
        {
            OpenConnection();
        }
        return _connection;
    }

    public static NpgsqlConnection OpenConnection()
    {
        if ((_connection is null) == false )
        {
            _connection.Close();
        }
        _connection = new NpgsqlConnection("Host=127.0.0.1;Database=DutyDistribution;User Id=postgres;Password=admin;");
        _connection.Open();
        
        return _connection;
    }
}