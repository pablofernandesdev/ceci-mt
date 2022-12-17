using CeciMT.Domain.DTO.Commons;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service.External
{
    public interface IFirebaseService
    {
        Task<ResultResponse> SendNotificationAsync(string token, string title, string body);
    }
}
