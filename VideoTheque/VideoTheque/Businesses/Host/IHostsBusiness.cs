using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Hosts
{
    public interface IHostsBusiness
    {
        Task<List<HostDto>> GetHosts();

        HostDto GetHost(int id);

        HostDto InsertHost(HostDto Host);

        void UpdateHost(int id, HostDto Host);

        void DeleteHost(int id);
    }
}
