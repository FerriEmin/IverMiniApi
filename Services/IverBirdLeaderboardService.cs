using IverMiniApi.Models;
using Dapper;
using System.Data;
using IverMiniApi.DB;


namespace IverMiniApi.Services
{
    public class IverBirdLeaderboardService : IIverBirdLeaderboardService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public IverBirdLeaderboardService(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> AddScoreAsync(IverBirdLeaderboard playerAndScore)
        { 
            
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                               @"INSERT INTO IverBirdLeaderboard (Name, Score, CreatedAt) VALUES (@Name, @Score, @CreatedAt)",
                                              new { Name = playerAndScore.Name, Score = playerAndScore.Score, CreatedAt = DateTime.Now }
                                                         );
            return result > 0;
        }
        public Task<bool> DeletePlayerAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IverBirdLeaderboard>> GetLeaderboardAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<IverBirdLeaderboard>("SELECT * FROM IverBirdLeaderboard ORDER BY Score DESC");

        }

        public Task<IverBirdLeaderboard?> GetPlayerByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
