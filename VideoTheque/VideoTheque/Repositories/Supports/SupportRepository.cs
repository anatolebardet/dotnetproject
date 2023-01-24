using System.Xml.Linq;
using VideoTheque.Constants;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public class SupportRepository : ISupportsRepository
    {
        public Task<List<SupportDto>> GetSupports()
        {
            var list = new List<SupportDto>
            {
                new SupportDto
                {
                    Id = (int)SupportEnums.Bluray,
                    Name = (string)SupportEnums.Bluray.ToString()
                }
            };
            var result = Task.FromResult(list);
            return result;
        }

        public SupportDto GetSupport(int id)
        {
            var support = (SupportEnums)id;
            return new SupportDto(Id: (int)support, name: "BluRay");
        }

        public object GetOrCreate(object support)
        {
            throw new NotImplementedException();
        }
    }
}
