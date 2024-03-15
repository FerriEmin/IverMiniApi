using IverMiniApi.Models;

namespace IverMiniApi.Services
{
    public interface IIverBirdLeaderboardService
    {
        public Task<bool> AddScoreAsync(IverBirdLeaderboard playerAndScore);
        public Task<IverBirdLeaderboard?> GetPlayerByNameAsync(string name);
        public Task<IEnumerable<IverBirdLeaderboard>> GetLeaderboardAsync();
        public Task<bool> DeletePlayerAsync(string name);
    }
}
