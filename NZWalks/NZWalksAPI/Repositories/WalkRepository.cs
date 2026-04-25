using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public async  Task<Walk> CreateWalkAsync(Walk walks)
        {
            //perform database call

            await nZWalksDbContext.Walks.AddAsync(walks);
            await nZWalksDbContext.SaveChangesAsync();
            return walks;

        }

        public async Task<Walk> DeleteWalk(Guid id)
        {
            var result = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(result==null)
            {
                return null;
            }

            nZWalksDbContext.Walks.Remove(result);
            await nZWalksDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await nZWalksDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
           return  await nZWalksDbContext.Walks.FirstOrDefaultAsync(x=>x.Id== id);

        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingwalk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalk == null)
            {
                return null;
            }
            existingwalk.Name= walk.Name;
            existingwalk.lengthinkms=walk.lengthinkms;
            existingwalk.RegionId=walk.RegionId;
            existingwalk.DifficultyId=walk.DifficultyId;
            existingwalk.Description=walk.Description;

            await nZWalksDbContext.SaveChangesAsync();
            return existingwalk;

            
        }
    }
}
