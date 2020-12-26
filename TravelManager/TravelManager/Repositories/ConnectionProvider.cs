using MySql.Data.MySqlClient;

namespace TravelManager.Repositories
{
    public class ConnectionProvider : IConnectionProvider
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public ConnectionProvider(string connectionString)
        {
            this._connectionString = connectionString;
            this._connection = new MySqlConnection(_connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return _connection ?? new MySqlConnection(_connectionString);
        }
    }
}