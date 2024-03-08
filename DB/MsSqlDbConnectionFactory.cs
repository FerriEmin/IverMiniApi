using Microsoft.Data.SqlClient;
using System.Data;

namespace IverMiniApi.DB

{
    public class MsSqlDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public MsSqlDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
