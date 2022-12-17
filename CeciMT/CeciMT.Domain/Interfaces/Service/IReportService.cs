using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface IReportService
    {
        Task<ResultResponse<byte[]>> GenerateUsersReport(UserFilterDTO filter);
    }
}
