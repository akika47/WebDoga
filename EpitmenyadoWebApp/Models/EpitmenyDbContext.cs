using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EpitmenyadoWebApp.Models
{
    public class EpitmenyDbContext : DbContext
    {
        public EpitmenyDbContext(DbContextOptions<EpitmenyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Telkek> Telkeks { get; set; }
    }
}
