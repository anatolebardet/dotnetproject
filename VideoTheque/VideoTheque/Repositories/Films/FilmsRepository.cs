using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Films
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly VideothequeDb _db;

        public FilmsRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<FilmDto>> GetFilms() => _db.Films.ToListAsync();

        public ValueTask<FilmDto?> GetFilm(int id) => _db.Films.FindAsync(id);

        public Task InsertFilm(FilmDto film)
        {
            _db.Films.AddAsync(film);
            return _db.SaveChangesAsync();
        }

        public Task UpdateFilm(int id, FilmDto film)
        {
            var filmToUpdate = _db.Films.FindAsync(id).Result;

            if (filmToUpdate is null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            filmToUpdate.Name = film.Name;
            return _db.SaveChangesAsync();
        }

        public Task DeleteFilm(int id)
        {
            var filmToDelete = _db.Films.FindAsync(id).Result;

            if (filmToDelete is null)
            {
                throw new KeyNotFoundException($"Film '{id}' non trouvé");
            }

            _db.Films.Remove(filmToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
