using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Films;

namespace VideoTheque.Businesses.Films
{
    public class FilmsBusiness : IFilmsBusiness
    {
        private readonly IFilmsRepository _filmDao;

        public FilmsBusiness(IFilmsRepository filmDao)
        {
            _filmDao = filmDao;
        }

        public Task<List<FilmDto>> GetFilms() => _filmDao.GetFilms();

        public FilmDto GetFilm(int id)
        {
            var film = _filmDao.GetFilm(id).Result;

            if (film == null)
            {
                throw new NotFoundException($"Film '{id}' non trouvé");
            }

            return film;
        }

        public FilmDto InsertFilm(FilmDto film)
        {
            if (_filmDao.InsertFilm(film).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du film {film.Name}");
            }

            return film;
        }

        public void UpdateFilm(int id, FilmDto film)
        {
            if (_filmDao.UpdateFilm(id, film).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du film {film.Name}");
            }
        }


        public void DeleteFilm(int id)
        {
            if (_filmDao.DeleteFilm(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du film d'identifiant {id}");
            }
        }
    }
}
