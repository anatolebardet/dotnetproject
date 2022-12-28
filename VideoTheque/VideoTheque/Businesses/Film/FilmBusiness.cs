using VideoTheque.Constants;
using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Films;

namespace VideoTheque.Businesses.Film
{
    public class FilmBusiness : IFilmBusiness
    {

        private readonly IFilmsRepository _bluRaysDao;

        public FilmBusiness(IFilmsRepository bluRaysDao)
        {
            _bluRaysDao = bluRaysDao;
        }
        public void DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public FilmDto GetFilm(int id)
        {
            FilmDto film = new FilmDto
            {
                Id = (int)_bluRaysDao.GetFilm(id).Result.Id,
                IdScenarist = (int)_bluRaysDao.GetFilm(id).Result.IdScenarist,
                IdDirector = (int)_bluRaysDao.GetFilm(id).Result.IdDirector,
                IdGenre = (int)_bluRaysDao.GetFilm(id).Result.IdGenre,
                IdFirstActor = (int)_bluRaysDao.GetFilm(id).Result.IdFirstActor,
                IdAgeRating = (int)_bluRaysDao.GetFilm(id).Result.IdAgeRating,
                IdSupport = (int)SupportEnums.Bluray,
                Duration = (long)_bluRaysDao.GetFilm(id).Result.Duration,
                Title = (string)_bluRaysDao.GetFilm(id).Result.Title,
            };
            if (film == null)
            {
                throw new NotFoundException($"Film '{id}' non trouvé");
            }

            return film;
        }

        public Task<List<FilmDto>> GetFilms()
        {
            throw new NotImplementedException();
        }

        public FilmDto InsertFilm(FilmDto film)
        {
            throw new NotImplementedException();
        }

        public void UpdateFilm(int id, FilmDto film)
        {
            throw new NotImplementedException();
        }
    }
}
