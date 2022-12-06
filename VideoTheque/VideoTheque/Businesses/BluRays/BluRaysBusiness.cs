using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.BluRays;

namespace VideoTheque.Businesses.BluRays
{
    public class BluRaysBusiness : IBluRaysBusiness
    {
        private readonly IBluRaysRepository _bluRayDao;

        public BluRaysBusiness(IBluRaysRepository bluRayDao)
        {
            _bluRayDao = bluRayDao;
        }

        public Task<List<BluRayDto>> GetBluRays() => _bluRayDao.GetBluRays();

        public BluRayDto GetBluRay(int id)
        {
            var bluRay = _bluRayDao.GetBluRay(id).Result;

            if (bluRay == null)
            {
                throw new NotFoundException($"BluRay '{id}' non trouvé");
            }

            return bluRay;
        }

        public BluRayDto InsertBluRay(BluRayDto bluRay)
        {
            if (_bluRayDao.InsertBluRay(bluRay).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du bluRay {bluRay.Title}");
            }

            return bluRay;
        }

        public void UpdateBluRay(int id, BluRayDto bluRay)
        {
            if (_bluRayDao.UpdateBluRay(id, bluRay).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du bluRay {bluRay.Title}");
            }
        }


        public void DeleteBluRay(int id)
        {
            if (_bluRayDao.DeleteBluRay(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du bluRay d'identifiant {id}");
            }
        }
    }
}
