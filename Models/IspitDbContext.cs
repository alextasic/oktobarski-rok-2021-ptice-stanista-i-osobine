using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        public DbSet<Ptica> Ptica{get;set;}

        public DbSet<Podrucje> Podrucje{get;set;}

        public DbSet<Osobina> Osobina{get;set;} 

        public DbSet<PticaPodrucje> PticaPodrucje{get;set;}

        // DbSet...

        public IspitDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
