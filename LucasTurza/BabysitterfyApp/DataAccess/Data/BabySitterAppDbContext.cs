using BabysitterfyApp.Models;

namespace BabysitterfyApp.DataAccess.Data
{
    public class BabySitterAppDbContext : DbContext
    {
        public DbSet<BabySitter> BabySitter { get; set; }
        public BabySitterAppDbContext(DbContextOptions<BabySitterAppDbContext> options) : base (options)
        {
        }
    }
}
