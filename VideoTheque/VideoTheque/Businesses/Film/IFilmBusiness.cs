using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Film
{
    public interface IFilmBusiness
    {
        List<FilmDto> GetFilms();

        FilmDto GetFilm(int id);

        FilmDto InsertFilm(FilmDto film);

        void UpdateFilm(int id, FilmDto film);

        void DeleteFilm(int id);
    }
}
