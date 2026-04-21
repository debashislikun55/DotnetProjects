using Azure.Core;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async  Task<List<Region>> GetAllAsync()
        {
           return  await nZWalksDbContext.Region.ToListAsync();
        }

        public async Task<Region?> GetRegionByIDAsync(Guid id)
        {
            return await nZWalksDbContext.Region.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await nZWalksDbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.code = region.code;
            existingRegion.name = region.name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await nZWalksDbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
