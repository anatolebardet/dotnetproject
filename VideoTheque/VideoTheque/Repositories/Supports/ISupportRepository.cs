using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public interface ISupportsRepository
    {
        public Task<List<SupportDto>> GetSupports();

        public SupportDto GetSupport(int id);
    }
}
