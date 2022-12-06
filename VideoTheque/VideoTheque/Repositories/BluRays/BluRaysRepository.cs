using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.BluRays
{
    public class BluRaysRepository : IBluRaysRepository
    {
        private readonly VideothequeDb _db;

        public BluRaysRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<BluRayDto>> GetBluRays() => _db.BluRays.ToListAsync();

        public ValueTask<BluRayDto?> GetBluRay(int id) => _db.BluRays.FindAsync(id);

        public Task InsertBluRay(BluRayDto bluRay)
        {
            _db.BluRays.AddAsync(bluRay);
            return _db.SaveChangesAsync();
        }

        public Task UpdateBluRay(int id, BluRayDto bluRay)
        {
            var bluRayToUpdate = _db.BluRays.FindAsync(id).Result;

            if (bluRayToUpdate is null)
            {
                throw new KeyNotFoundException($"BluRay '{id}' non trouvé");
            }

            bluRayToUpdate.Title = bluRay.Title;
            return _db.SaveChangesAsync();
        }

        public Task DeleteBluRay(int id)
        {
            var bluRayToDelete = _db.BluRays.FindAsync(id).Result;

            if (bluRayToDelete is null)
            {
                throw new KeyNotFoundException($"BluRay '{id}' non trouvé");
            }

            _db.BluRays.Remove(bluRayToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
