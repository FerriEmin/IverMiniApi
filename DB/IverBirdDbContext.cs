using Microsoft.EntityFrameworkCore;

namespace IverMiniApi.DB
{
    public class IverBirdDbContext : DbContext
    {
        public IverBirdDbContext(DbContextOptions<IverBirdDbContext> options) : base(options)
        {

        }
        public DbSet<IverBirdPlayers> IverBirdPlayer { get; set; }

    }
}
