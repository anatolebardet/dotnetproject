using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Personnes
{
    public class PersonnesBusiness : IPersonnesBusiness
    {
        private readonly IPersonnesRepository _PersonneDao;

        public PersonnesBusiness(IPersonnesRepository personneDao)
        {
            _PersonneDao = personneDao;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _PersonneDao.GetPersonnes();

        public PersonneDto GetPersonne(int id)
        {
            var personne = _PersonneDao.GetPersonne(id).Result;

            if (personne == null)
            {
                throw new NotFoundException($"Personne '{id}' non trouvé");
            }

            return Personne;
        }

        public PersonneDto InsertPersonne(PersonneDto personne)
        {
            if (_PersonneDao.InsertPersonne(personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du Personne {Personne.Name}");
            }

            return Personne;
        }

        public void UpdatePersonne(int id, PersonneDto Personne)
        {
            if (_PersonneDao.UpdatePersonne(id, personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du Personne {personne.Name}");
            }
        }


        public void DeletePersonne(int id)
        {
            if (_PersonneDao.DeletePersonne(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du Personne d'identifiant {id}");
            }
        }
    }
}
