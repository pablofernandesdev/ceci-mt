using Microsoft.AspNetCore.Http;

namespace CeciMT.Domain.DTO.Import
{
    public class FileUploadDTO
    {
        /// <summary>
        /// File for import
        /// </summary>
        public IFormFile File { get; set; }
    }
}
