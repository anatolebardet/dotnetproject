using System.Reflection;
using VideoTheque.Businesses.BluRays;
using VideoTheque.Constants;
using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Films;

namespace VideoTheque.Businesses.Film
{
    public class FilmBusiness : IFilmBusiness
    {

        private readonly IFilmsRepository _bluRaysDao;
        private readonly IBluRaysBusiness _bluRaysBusiness;

        public FilmBusiness(IFilmsRepository bluRaysDao)
        {
            _bluRaysDao = bluRaysDao;
        }
        public void DeleteFilm(int id)
        {
            if (_bluRaysDao.DeleteFilm(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du film d'identifiant {id}");
            }
        }

        public FilmDto GetFilm(int id)
        {
            FilmDto film = new FilmDto();
            BluRayDto bluray = new BluRayDto();
            try
            {
                bluray = _bluRaysDao.GetFilm(id).Result;
            }
            catch(System.NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(bluray != null)
            {
                film = new FilmDto()
                {
                    Id = (int)bluray.Id,
                    IdScenarist = (int)bluray.IdScenarist,
                    IdDirector = (int)bluray.IdDirector,
                    IdGenre = (int)bluray.IdGenre,
                    IdFirstActor = (int)bluray.IdFirstActor,
                    IdAgeRating = (int)bluray.IdAgeRating,
                    IdSupport = (int)SupportEnums.Bluray,
                    Duration = (long)bluray.Duration,
                    Title = (string)bluray.Title,
                };
            }
            else
            {
                throw new NotFoundException($"Film '{id}' non trouvé");
            }

            return film;
        }

        public List<FilmDto> GetFilms()
        {
            List<FilmDto> films = new List<FilmDto>();
            List<BluRayDto> blurays = _bluRaysDao.GetFilms().Result;
            foreach(BluRayDto bluray in blurays)
            {
                films.Add(new FilmDto()
                {
                    Id = (int)bluray.Id,
                    IdScenarist = (int)bluray.IdScenarist,
                    IdDirector = (int)bluray.IdDirector,
                    IdGenre = (int)bluray.IdGenre,
                    IdFirstActor = (int)bluray.IdFirstActor,
                    IdAgeRating = (int)bluray.IdAgeRating,
                    IdSupport = (int)SupportEnums.Bluray,
                    Duration = (long)bluray.Duration,
                    Title = (string)bluray.Title

                });
            }
            return films;
        }

        public FilmDto InsertFilm(FilmDto film)
        {
            BluRayDto bluray = new BluRayDto()
            {
                Id = (int)film.Id,
                Title = (string)film.Title,
                Duration = (long)film.Duration,
                IdFirstActor = (int)film.IdFirstActor,
                IdDirector = (int)film.IdDirector,
                IdScenarist = (int)film.IdScenarist,
                IdAgeRating = (int)film.IdAgeRating,
                IdGenre = (int)film.IdGenre,
                IsAvailable = true,
                IdOwner = null

            };
            if (_bluRaysDao.InsertFilm(bluray).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du film {film.Title}");
            }

            return film;
        }

        public void UpdateFilm(int id, FilmDto film)
        {
            BluRayDto bluray = new BluRayDto()
            {
                Id = (int)film.Id,
                Title = (string)film.Title,
                Duration = (long)film.Duration,
                IdFirstActor = (int)film.IdFirstActor,
                IdDirector = (int)film.IdDirector,
                IdScenarist = (int)film.IdScenarist,
                IdAgeRating = (int)film.IdAgeRating,
                IdGenre = (int)film.IdGenre

            };
            if (_bluRaysDao.UpdateFilm(id, bluray).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {film.Title}");
            }
        }
    }
}
