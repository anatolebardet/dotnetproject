using System;
using VideoTheque.Businesses.BluRays;
using VideoTheque.Businesses.Film;
using VideoTheque.Businesses.Emprunt;
using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.AgeRatings;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Emprunts;
using VideoTheque.Repositories.Films;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Personnes;
using VideoTheque.Repositories.Supports;
using VideoTheque.Businesses.Emprunts;

namespace VideoTheque.Businesses.Emprunt
{
    public class EmpruntBusiness : IEmpruntsBusiness
    {
        private readonly IEmpruntsRepository _empruntDao;
        private readonly IFilmsRepository _filmDao;
        private readonly IPersonnesRepository _personneDao;
        private readonly IGenresRepository _genreDao;
        private readonly ISupportsRepository _supportDao;
        private readonly IAgeRatingsRepository _ageRatingDao;


        public EmpruntBusiness(IEmpruntsRepository empruntDao, IFilmsRepository filmDao, IPersonnesRepository personneDao, IGenresRepository genreDao, IAgeRatingsRepository ageRatingDao, ISupportsRepository supportDao)
        {
            _empruntDao = empruntDao;
            _filmDao = filmDao;
            _personneDao = personneDao;
            _genreDao = genreDao;
            _ageRatingDao = ageRatingDao;
            _supportDao = supportDao;
        }

        public Task AddEmprunt(BluRayDto bluRay)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmpruntDto>> GetAllEmprunts()
        {
            throw new NotImplementedException();
        }

        public Task<BluRayDto> GetEmprunt(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmprunt(int id, BluRayDto bluRay)
        {
            throw new NotImplementedException();
        }

        /*public async Task<EmpruntDto> EmpruntFilm(int idFilmPartenaire, int idPartenaire)
{
   var film = await _filmDao.GetFilmByPartenaire(idFilmPartenaire, idPartenaire);
   if (film == null)
   {
       throw new NotFoundException($"Film '{idFilmPartenaire}' not found in partner '{idPartenaire}'");
   }
   if (film.IsAvailable==false)
   {
       throw new BadRequestException($"Film '{idFilmPartenaire}' is not available in partner '{idPartenaire}'");
   }
   //update the film status in the partner's database
   await _filmDao.UpdateFilmPartenaire(idFilmPartenaire, idPartenaire, false);

   //create the emprunt object
   var emprunt = new EmpruntDto()
   {
       Id = film.Id,
   };

   //check if the director already exists in the database
   var director = await _personneDao.GetPersonne((int)film.IdDirector);
   if (director == null)
   {
       var newDirector = new PersonneDto
       {
           LastName = director.LastName.Split(" ")[1],
           FirstName = director.FirstName.Split(" ")[0],
           Nationality = director.Nationality,
           BirthDay = director.BirthDay,
       };
       emprunt.Director = await _personneDao.InsertPersonne(newDirector);
   }
   else
   {
       emprunt.Director = director;
   }
   var scenarist = await _personneDao.GetPersonne((int)film.IdScenarist);
   if (scenarist == null)
   {
       var newScenarist = new PersonneDto
       {
           LastName = scenarist.LastName.Split(" ")[1],
           FirstName = scenarist.FirstName.Split(" ")[0],
           Nationality = scenarist.Nationality,
           BirthDay = scenarist.BirthDay,
       };
       emprunt.Scenarist = await _personneDao.InsertPersonne(newScenarist);
   }
   else
   {
       emprunt.Scenarist = scenarist;
   }
   //Get the support
   var support = await _supportDao.GetSupport(1);
   //check if the age rating exists in the db, if not insert it
   var ageRating = await _ageRatingDao.GetAgeRating(film.IdAgeRating);
   if (ageRating == null)
   {
       var newAgeRating = new AgeRatingDto
       {
           Name = ageRating.Name,
           Abreviation = ageRating.Abbreviation
       };
       emprunt.AgeRating = await _ageRatingDao.InsertAgeRating(newAgeRating);
   }
   else
   {
       emprunt.AgeRating = ageRating;
   }
   //Check if the genre exists in the db, if not insert it
   var genre = await _genreDao.GetGenre((int)film.IdGenre);
   if (genre == null)
   {
       var newGenre = new GenreDto
       {
           Name = genre.Name,
       };
       emprunt.Genre = await _genreDao.InsertGenre(newGenre);
   }
   else
   {
       emprunt.Genre = genre;
   }
   //check if the first actor exists in the db, if not insert it
   var firstActor = await _personneDao.GetPersonne((int)film.IdFirstActor);
   if (firstActor == null)
   {
   var newFirstActor = new PersonneDto
               {
                   LastName = firstActor.LastName.Split(" ")[1],
                   FirstName = firstActor.FirstName.Split(" ")[0],
                   Nationality = firstActor.Nationality,
                   BirthDay = firstActor.BirthDay,
               };
               emprunt.FirstActor = await _personneDao.InsertPersonne(newFirstActor);
   }

   else
       {
       emprunt.FirstActor = firstActor;
       }

       

        var newFilm = new FilmDto()
        {
            Scenarist = emprunt.Scenarist,
            Director = emprunt.Director,
            Genre = emprunt.genre,
            FirstActor = emprunt.FirstActor,
            AgeRating = emprunt.AgeRating,
            Duration = emprunt.Duration,
            Title = emprunt.Title,
            IsAvailable = false,
            };

   await _filmDao.InsertFilm(newFilm);

}
*/

    }
}
        