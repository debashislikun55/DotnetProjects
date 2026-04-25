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


        //seed data for difficulties 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difficulties = new List<Difficulty>
            {
                   new Difficulty()
                   {
                       Id=Guid.Parse("9834664c-58fe-41f3-b213-4ac3c96e7a42"),
                       Name="Easy"
                   },
                   new Difficulty()
                   {
                       Id=Guid.Parse("55890013-7386-4920-b508-017f4ae0c71f"),
                       Name="Medium"
                   },
                   new Difficulty()
                   {
                       Id=Guid.Parse("a6bcf8e3-8d70-4d9d-98ef-e5c5d75c708e"),
                       Name="Hard"
                   }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                new Region()
                {
                    Id=Guid.Parse("2fe54e01-21a8-41bf-9dae-a9033c863bd0"),
                    name="Auckland",
                    code="AKL",
                    RegionImageUrl="https://AKL.url"
                },
                new Region()
                {
                    Id=Guid.Parse("f2c84407-ce28-4952-b3e7-bfd60ecc3044"),
                    name="Northland",
                    code="NTL",
                    RegionImageUrl="https://ntl.url"
                },
                new Region()
                {
                    Id=Guid.Parse("1368538a-efe5-412b-81f0-b7d030486884"),
                    name="Bay of plenty",
                    code="BOP",
                    RegionImageUrl=null
                },
                new Region()
                {
                    Id=Guid.Parse("1368538a-efe5-412b-81f0-b7e030476884"),
                    name="Southland",
                    code="STL",
                    RegionImageUrl=null
                }

            };
            modelBuilder.Entity<Region>().HasData(regions);

             
        }

    }

    
}
