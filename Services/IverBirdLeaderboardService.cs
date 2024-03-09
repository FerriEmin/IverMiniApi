using IverMiniApi.Models;
using Dapper;
using System.Data;
using IverMiniApi.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IverMiniApi.Services
{
    public class IverBirdLeaderboardService : IIverBirdLeaderboardService
    {
        private readonly DataContext _context;
        public IverBirdLeaderboardService(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddScoreAsync(IverBirdLeaderboard playerAndScore)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlayerAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IverBirdLeaderboard>> GetAllPlayerScoresAsync()
        {
            var players = await _context.IverBirdLeaderboard.ToListAsync();
            return players;
        }

        public Task<IverBirdLeaderboard?> GetPlayerByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
