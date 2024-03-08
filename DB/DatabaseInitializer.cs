using Dapper;

namespace IverMiniApi.DB

{
    public class DatabaseInitializer
    {
        
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(
                @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'IverBirdLeaderboard')
            CREATE TABLE IverBirdLeaderboard (
                Id INT PRIMARY KEY IDENTITY,
                Name NVARCHAR(50) NOT NULL,
                Score INT NOT NULL,
                CreatedAt DATETIME NOT NULL
            )"
            );
        }

    }
}
