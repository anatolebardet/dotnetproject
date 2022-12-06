using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Personnes
{
    public class PersonnesBusiness : IPersonnesBusiness
    {
        private readonly IPersonnesRepository _personneDao;

        public PersonnesBusiness(IPersonnesRepository personneDao)
        {
            _personneDao = personneDao;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _personneDao.GetPersonnes();

        public PersonneDto GetPersonne(int id)
        {
            var personne = _personneDao.GetPersonne(id).Result;

            if (personne == null)
            {
                throw new NotFoundException($"Personne '{id}' non trouvé");
            }

            return Personne;
        }

        public PersonneDto InsertPersonne(PersonneDto personne)
        {
            if (_personneDao.InsertPersonne(personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du Personne {Personne.Name}");
            }

            return Personne;
        }

        public void UpdatePersonne(int id, PersonneDto Personne)
        {
            if (_personneDao.UpdatePersonne(id, personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du Personne {personne.Name}");
            }
        }


        public void DeletePersonne(int id)
        {
            if (_personneDao.DeletePersonne(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du Personne d'identifiant {id}");
            }
        }
    }
}
