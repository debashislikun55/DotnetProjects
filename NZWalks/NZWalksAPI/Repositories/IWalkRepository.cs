using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walks);

        Task<List<Walk>> GetAllWalksAsync();

        Task<Walk> GetWalkByIdAsync(Guid id);

        Task<Walk> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk> DeleteWalk(Guid id);
    }
}
