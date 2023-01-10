using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Emprunts
{
    public class EmpruntsRepository : IEmpruntsRepository
    {
        private readonly VideothequeDb _db;

        public EmpruntsRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<EmpruntDto>> GetEmprunts() => (Task<List<EmpruntDto>>)_db.BluRays.ForEachAsync(BluRays => { _ = BluRays.IdOwner != null; });

        public Task InsertEmprunt(BluRayDto bluRay)
        {
            _db.BluRays.AddAsync(bluRay);
            return _db.SaveChangesAsync();
        }


        public ValueTask<BluRayDto> GetEmprunt(int id) => _db.BluRays.FindAsync(id);
        
        public Task UpdateEmprunt(int id,BluRayDto bluRay)
        {
            var bluRayToUpdate = _db.BluRays.FindAsync(id).Result;

            if (bluRayToUpdate is null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            bluRayToUpdate.Title = bluRay.Title;
            bluRayToUpdate.Duration = bluRay.Duration;
            bluRayToUpdate.IdDirector = bluRay.IdDirector;
            bluRayToUpdate.IdGenre = bluRay.IdGenre;
            bluRayToUpdate.IdScenarist = bluRay.IdScenarist;
            bluRayToUpdate.Duration = bluRay.Duration;
            bluRayToUpdate.IdAgeRating = bluRay.IdAgeRating;
            bluRayToUpdate.IsAvailable = bluRay.IsAvailable;
            bluRayToUpdate.IdOwner = bluRay.IdOwner;
            return _db.SaveChangesAsync();
        }

    }
}
