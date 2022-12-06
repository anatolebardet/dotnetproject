using VideoTheque.DTOs;

namespace VideoTheque.Businesses.BluRays
{
    public interface IBluRaysBusiness
    {
        Task<List<BluRayDto>> GetBluRays();

        BluRayDto GetBluRay(int id);

        BluRayDto InsertBluRay(BluRayDto BluRay);

        void UpdateBluRay(int id, BluRayDto BluRay);

        void DeleteBluRay(int id);
    }
}
