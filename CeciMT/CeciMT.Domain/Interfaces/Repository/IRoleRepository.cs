using CeciMT.Domain.Entities;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetBasicProfile();
    }
}
