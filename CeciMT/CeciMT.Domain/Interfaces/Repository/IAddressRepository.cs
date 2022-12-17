using CeciMT.Domain.DTO.Address;
using CeciMT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Repository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> GetLoggedUserAddressesAsync(int userId, AddressFilterDTO filter);
        Task<int> GetTotalLoggedUserAddressesAsync(int userId, AddressFilterDTO filter);
        Task<IEnumerable<Address>> GetByFilterAsync(AddressFilterDTO filter);
        Task<int> GetTotalByFilterAsync(AddressFilterDTO filter);
    }
}
