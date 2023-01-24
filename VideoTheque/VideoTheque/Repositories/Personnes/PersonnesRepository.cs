using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Personnes
{
    public class PersonnesRepository : IPersonnesRepository
    {
        private readonly VideothequeDb _db;

        public PersonnesRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _db.Personnes.ToListAsync();

        public ValueTask<PersonneDto?> GetPersonne(int id) => _db.Personnes.FindAsync(id);

        public Task InsertPersonne(PersonneDto personne)
        {
            _db.Personnes.AddAsync(personne);
            return _db.SaveChangesAsync();
        }

        public Task UpdatePersonne(int id, PersonneDto personne)
        {
            var personneToUpdate = _db.Personnes.FindAsync(id).Result;

            if (personneToUpdate is null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            personneToUpdate.FirstName = personne.FirstName;
            return _db.SaveChangesAsync();
        }

        public Task DeletePersonne(int id)
        {
            var personneToDelete = _db.Personnes.FindAsync(id).Result;

            if (personneToDelete is null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            _db.Personnes.Remove(personneToDelete);
            return _db.SaveChangesAsync();
        }

/*        public Task GetOrCreate(PersonneDto personne)
        {
            var existingPerson = _db.Personnes.FirstOrDefault(p => p.LastName == personne.LastName);
            if (existingPerson != null)
            {
                _db.Personnes.FindAsync(existingPerson.Id);
            }
            else
            {
                _db.Personnes.AddAsync(personne);
            }
            return _db.SaveChangesAsync();
        }*/

    }
}
