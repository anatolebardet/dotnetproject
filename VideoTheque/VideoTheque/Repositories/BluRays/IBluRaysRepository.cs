using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.BluRays
{
    public interface IBluRaysRepository
    {
        Task<List<BluRaysDto>> GetBluRays();

        ValueTask<BluRaysDto?> GetBluRays(int id);

        Task InsertBluRays(BluRaysDto bluRays);

        Task UpdateBluRays(int id, BluRaysDto bluRays);

        Task DeleteBluRays(int id);
    }
}
