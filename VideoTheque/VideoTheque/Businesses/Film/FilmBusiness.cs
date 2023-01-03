using System.Reflection;
using VideoTheque.Businesses.BluRays;
using VideoTheque.Constants;
using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.AgeRatings;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Films;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Personnes;
using VideoTheque.Repositories.Supports;

namespace VideoTheque.Businesses.Film
{
    public class FilmBusiness : IFilmBusiness
    {

        private readonly IFilmsRepository _bluRayDao;
        private readonly IPersonnesRepository _personneDao;
        private readonly IGenresRepository _genreDao;
        private readonly ISupportsRepository _supportDao;
        private readonly IAgeRatingsRepository _ageRatingDao;

        public FilmBusiness(IFilmsRepository bluRaysDao, IPersonnesRepository personnesDao, 
            IGenresRepository genreDao, IAgeRatingsRepository ageRatingDao, ISupportsRepository supportDao)
        {
            _bluRayDao = bluRaysDao;
            _personneDao = personnesDao;
            _genreDao = genreDao;
            _supportDao = supportDao;
            _ageRatingDao = ageRatingDao;

        }
        public void DeleteFilm(int id)
        {
            if (_bluRayDao.DeleteFilm(id).IsFaulted)
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
                bluray = _bluRayDao.GetFilm(id).Result;
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
                    Scenarist = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    Director = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    Genre = _genreDao.GetGenre((int)bluray.IdGenre).Result,
                    FirstActor = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    AgeRating = _ageRatingDao.GetAgeRating(bluray.IdAgeRating).Result,
                    Support = _supportDao.GetSupport(1),
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
            List<BluRayDto> blurays = _bluRayDao.GetFilms().Result;
            PersonneDto _scenarist = new PersonneDto();
            foreach(BluRayDto bluray in blurays)
            {
                if (_personneDao.GetPersonne((int)bluray.IdScenarist).Result != null)
                {
                    _scenarist = _personneDao.GetPersonne((int)bluray.IdScenarist).Result;
                }
                films.Add(new FilmDto()
                {
                    Id = (int)bluray.Id,
                    Scenarist = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    Director = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    Genre = _genreDao.GetGenre((int)bluray.IdGenre).Result,
                    FirstActor = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result,
                    AgeRating = _ageRatingDao.GetAgeRating(bluray.IdAgeRating).Result,
                    Support = _supportDao.GetSupport((int)SupportEnums.Bluray),
                    Duration = (long)bluray.Duration,
                    Title = (string)bluray.Title,

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
                IdFirstActor = (int)film.FirstActor.Id,
                IdDirector = (int)film.Director.Id,
                IdScenarist = (int)film.Scenarist.Id,
                IdAgeRating = (int)film.AgeRating.Id,
                IdGenre = (int)film.Genre.Id,
                IsAvailable = true,
                IdOwner = null

            };
            if (_bluRayDao.InsertFilm(bluray).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du film {film.Title}");
            }
            else
            {
                _personneDao.InsertPersonne(film.FirstActor);
                _personneDao.InsertPersonne(film.Director);
                _personneDao.InsertPersonne(film.Scenarist);
                _genreDao.InsertGenre(film.Genre);
                _ageRatingDao.InsertAgeRating(film.AgeRating);
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
                IdFirstActor = (int)film.FirstActor.Id,
                IdDirector = (int)film.Director.Id,
                IdScenarist = (int)film.Scenarist.Id,
                IdAgeRating = (int)film.AgeRating.Id,
                IdGenre = (int)film.Genre.Id
            };
            if (_bluRayDao.UpdateFilm(id, bluray).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {film.Title}");
            }
            else
            {
                _personneDao.InsertPersonne(film.FirstActor);
                _personneDao.InsertPersonne(film.Director);
                _personneDao.InsertPersonne(film.Scenarist);
                _genreDao.InsertGenre(film.Genre);
                _ageRatingDao.InsertAgeRating(film.AgeRating);
            }
        }
    }
}
