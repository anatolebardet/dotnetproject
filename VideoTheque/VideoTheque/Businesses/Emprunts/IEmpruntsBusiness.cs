using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Emprunts
{
    public interface IEmpruntsBusiness
    {
        Task<List<EmpruntDto>> GetAllEmprunts();
        Task AddEmprunt(BluRayDto bluRay);
        Task<BluRayDto> GetEmprunt(int id);
        Task UpdateEmprunt(int id, BluRayDto bluRay);
    }
}
