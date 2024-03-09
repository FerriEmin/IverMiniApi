using IverMiniApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IverMiniApi.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<IverBirdLeaderboard> IverBirdLeaderboard { get; set; }
    }
}
