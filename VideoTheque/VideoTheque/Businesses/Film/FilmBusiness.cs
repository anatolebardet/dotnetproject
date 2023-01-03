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
                    Scenarist = _personneDao.GetPersonne((int)bluray.IdScenarist).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdScenarist).Result.LastName,
                    Director = _personneDao.GetPersonne((int)bluray.IdDirector).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdDirector).Result.LastName,
                    Genre = _genreDao.GetGenre((int)bluray.IdGenre).Result.Name,
                    FirstActor = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdFirstActor).Result.LastName,
                    AgeRating = _ageRatingDao.GetAgeRating(bluray.IdAgeRating).Result.Name,
                    Support = _supportDao.GetSupport(1).Name,
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
                    Scenarist = _personneDao.GetPersonne((int)bluray.IdScenarist).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdScenarist).Result.LastName,
                    Director = _personneDao.GetPersonne((int)bluray.IdDirector).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdDirector).Result.LastName,
                    Genre = _genreDao.GetGenre((int)bluray.IdGenre).Result.Name,
                    FirstActor = _personneDao.GetPersonne((int)bluray.IdFirstActor).Result.FirstName + " " + _personneDao.GetPersonne((int)bluray.IdFirstActor).Result.LastName,
                    AgeRating = _ageRatingDao.GetAgeRating(bluray.IdAgeRating).Result.Name,
                    Support = _supportDao.GetSupport(1).Name,
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
                IdFirstActor = GetPersonne(film.FirstActor).Id,
                IdDirector = GetPersonne(film.Director).Id,
                IdScenarist = GetPersonne(film.Scenarist).Id,
                IdAgeRating = GetAgeRating(film.AgeRating).Id,
                IdGenre = GetGenre(film.Genre).Id,
                IsAvailable = true,
                IdOwner = null

            };
            if (_bluRayDao.InsertFilm(bluray).IsFaulted)
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
                IdFirstActor = GetPersonne(film.FirstActor).Id,
                IdDirector = GetPersonne(film.Director).Id,
                IdScenarist = GetPersonne(film.Scenarist).Id,
                IdAgeRating = GetAgeRating(film.AgeRating).Id,
                IdGenre = GetGenre(film.Genre).Id
            };
            if (_bluRayDao.UpdateFilm(id, bluray).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {film.Title}");
            }
        }

        public PersonneDto GetPersonne(string name)
        {
            List<PersonneDto> personnes = _personneDao.GetPersonnes().Result;
            PersonneDto personneReturn = new PersonneDto();
            foreach(PersonneDto personne in personnes)
            {
                if(personne.FirstName + " " + personne.LastName == name)
                {
                    personneReturn = personne;
                }
            }
            return personneReturn;
        }

        public AgeRatingDto GetAgeRating(string name)
        {
            List<AgeRatingDto> ageRatings = _ageRatingDao.GetAgeRatings().Result;
            AgeRatingDto ageRatingReturn = new AgeRatingDto();
            foreach (AgeRatingDto ageRating in ageRatings)
            {
                if (ageRating.Name == name)
                {
                    ageRatingReturn = ageRating;
                }
            }
            return ageRatingReturn;
        }

        public GenreDto GetGenre(string name)
        {
            List<GenreDto> genres = _genreDao.GetGenres().Result;
            GenreDto genreReturn = new GenreDto();
            foreach (GenreDto genre in genres)
            {
                if (genre.Name == name)
                {
                    genreReturn = genre;
                }
            }
            return genreReturn;
        }
    }
}
