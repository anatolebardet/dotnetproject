using VideoTheque.Constants;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public class SupportRepository
    {
        public List<SupportDto>getSupports()
        {
            var result = new List<SupportDto>
            {
                new SupportDto
                {
                    Id= (int) SupportEnums.Bluray,
                    Name = (string) SupportEnums.Bluray.ToString(),
                }
            };
            return result;
        }
        public SupportDto getById(int id)
        {
            var support = (SupportEnums)id;
            return new SupportDto(Id = (int)support);
        }
    }
}
