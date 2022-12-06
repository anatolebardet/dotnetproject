using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.BluRayss
{
    public interface IBluRayssRepository
    {
        Task<List<BluRaysDto>> GetBluRayss();

        ValueTask<BluRaysDto?> GetBluRays(int id);

        Task InsertBluRays(BluRaysDto bluRays);

        Task UpdateBluRays(int id, BluRaysDto bluRays);

        Task DeleteBluRays(int id);
    }
}
