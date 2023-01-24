﻿using Microsoft.EntityFrameworkCore;
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

        /*public async Task<BluRayDto> GetFilmByPartenaire(int idFilmPartenaire, int idPartenaire)
        {
            // Query the data store to retrieve the film that matches the provided parameters
            var film = await _db.BluRays.FirstOrDefaultAsync(f => f.Id == idFilmPartenaire && f.IdOwner == idPartenaire);

            //return the result
            return film;
        }*/

       /* public Task UpdateFilmPartenaire(int idFilmPartenaire, int idPartenaire, bool v)
        {
            throw new NotImplementedException();
        }*/
    }
}
