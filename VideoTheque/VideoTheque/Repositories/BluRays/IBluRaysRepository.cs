using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.BluRays
{
    public interface IBluRaysRepository
    {
        Task<List<BluRayDto>> GetBluRays();

        ValueTask<BluRayDto?> GetBluRay(int id);

        Task InsertBluRay(BluRayDto bluRays);

        Task UpdateBluRay(int id, BluRayDto bluRays);

        Task DeleteBluRay(int id);
    }
}
