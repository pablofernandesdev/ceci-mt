using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.Import;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface IImportService
    {
        Task<ResultResponse> ImportUsersAsync(FileUploadDTO model);
    }
}
