using CeciMT.Domain.DTO.Address;
using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.ViaCep;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service.External
{
    public interface IViaCepService
    {
        Task<ResultResponse<ViaCepAddressResponseDTO>> GetAddressByZipCodeAsync(string zipCode);
    }
}
