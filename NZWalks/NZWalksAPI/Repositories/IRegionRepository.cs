using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
         Task<List<Region>> GetAllAsync();

         Task<Region?> GetRegionByIDAsync(Guid id);

         Task<Region> AddRegionAsync(Region region);

         Task<Region?> UpdateRegionAsync(Guid id ,Region region);


    }
}
