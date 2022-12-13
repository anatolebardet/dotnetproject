using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Supports;

namespace VideoTheque.Businesses.Supports
{
    public class SupportsBusiness : ISupportsBusiness
    {
        private readonly ISupportsRepository _supportDao;

        public SupportsBusiness(ISupportsRepository supportDao)
        {
            _supportDao = supportDao;
        }

        public void DeleteSupport(int id)
        {
            throw new NotImplementedException();
        }

        public SupportDto GetSupport(int id)
        {  
            var support = _supportDao.GetSupport(id);

            if (support == null)
            {
                throw new NotFoundException($"Support '{id}' non trouvé");
            }

            return support;
        }

        public Task<List<SupportDto>> GetSupports() => _supportDao.GetSupports();

        public SupportDto InsertSupport(SupportDto support)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupport(int id, SupportDto Support)
        {
            throw new NotImplementedException();
        }
    }
}
