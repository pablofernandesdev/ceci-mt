using CeciMT.Domain.DTO.Commons;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service.External
{
    public interface ISendGridService
    {
        Task<ResultResponse> SendEmailAsync(string email, string subject, string message);
    }
}
