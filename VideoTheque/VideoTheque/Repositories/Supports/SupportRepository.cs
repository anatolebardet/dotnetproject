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
                    Name = (string) SupportEnums.Bluray
                }
            }
        }
    }
}
