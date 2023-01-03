using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Films
{
    public interface IFilmsRepository
    {
        Task<List<BluRayDto>> GetFilms();

        ValueTask<BluRayDto?> GetFilm(int id);

        Task InsertFilm(BluRayDto bluRays);

        Task UpdateFilm(int id, BluRayDto bluRays);

        Task DeleteFilm(int id);

    }
}
