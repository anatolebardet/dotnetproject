using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Emprunts;

namespace VideoTheque.Businesses.Emprunts

{
    public class EmpruntBusiness
    {
        private readonly IEmpruntsRepository _empruntRepository;

        public EmpruntBusiness(IEmpruntsRepository empruntRepository)
        {
            _empruntRepository = empruntRepository;
        }

        public async Task<List<EmpruntDto>> GetAllEmprunts()
        {
            var bluRays = await _empruntRepository.GetEmprunts();

            var result = from br in bluRays
                         select new EmpruntDto
                         {
                             Id = br.Id,
                             Director = br.Director,
                             Scenarist = br.Scenarist,
                             Genre = br.Genre,
                             AgeRating = br.AgeRating,
                             Support = br.Support,
                             FirstActor = br.FirstActor,
                             Title = br.Title,
                             Duration = br.Duration
                         };
            return result.ToList();
        }

        public async Task AddEmprunt(BluRayDto bluRay)
        {
            await _empruntRepository.InsertEmprunt(bluRay);
        }

        public async Task<BluRayDto> GetEmprunt(int id)
        {
            return await _empruntRepository.GetEmprunt(id);
        }

        public async Task UpdateEmprunt(int id, BluRayDto bluRay)
        {
            await _empruntRepository.UpdateEmprunt(id, bluRay);
        }
    }
}
