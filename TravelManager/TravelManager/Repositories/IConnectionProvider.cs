using MySql.Data.MySqlClient;

namespace TravelManager.Repositories
{
    public interface IConnectionProvider
    {
        MySqlConnection GetConnection();
    }
}