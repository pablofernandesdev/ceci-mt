using CeciMT.Domain.DTO.User;
using CeciMT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetByFilterAsync(UserFilterDTO filter);
        Task<int> GetTotalByFilterAsync(UserFilterDTO filter);
    }
}
