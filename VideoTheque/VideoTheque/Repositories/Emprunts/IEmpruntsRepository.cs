using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Emprunts
{
    public interface IEmpruntsRepository
    {
        Task<List<EmpruntDto>> GetEmprunts();
        Task InsertEmprunt(BluRayDto bluRay);
        ValueTask<BluRayDto> GetEmprunt(int id);
        Task UpdateEmprunt(int id, BluRayDto bluRay);
    }
}