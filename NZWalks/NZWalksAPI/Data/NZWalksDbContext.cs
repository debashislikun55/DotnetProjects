using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext:DbContext

    {

        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulty { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<Walk> Walks { get; set; }
        
    }

    
}
