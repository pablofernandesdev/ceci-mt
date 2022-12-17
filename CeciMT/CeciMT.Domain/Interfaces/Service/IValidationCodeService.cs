using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.ValidationCode;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface IValidationCodeService
    {
        Task<ResultResponse> SendAsync();
        Task<ResultResponse> ValidateCodeAsync(ValidationCodeValidateDTO obj);
    }
}
