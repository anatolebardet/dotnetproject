using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Genres;

namespace VideoTheque.Repositories.Films
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly VideothequeDb _db;

        public FilmsRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<BluRayDto>> GetFilms() => _db.BluRays.ToListAsync();

        public ValueTask<BluRayDto> GetFilm(int id) => _db.BluRays.FindAsync(id);

        public Task InsertFilm(BluRayDto bluRay)
        {
            _db.BluRays.AddAsync(bluRay);
            return _db.SaveChangesAsync();
        }

        public Task UpdateFilm(int id, BluRayDto bluRay)
        {
            var bluRayToUpdate = _db.BluRays.FindAsync(id).Result;

            if (bluRayToUpdate is null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            bluRayToUpdate.Title = bluRay.Title;
            return _db.SaveChangesAsync();
        }

        public Task DeleteFilm(int id)
        {
            var bluRayToDelete = _db.BluRays.FindAsync(id).Result;

            if (bluRayToDelete is null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            _db.BluRays.Remove(bluRayToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
