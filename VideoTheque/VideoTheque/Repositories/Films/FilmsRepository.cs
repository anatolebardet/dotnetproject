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
    }
}
