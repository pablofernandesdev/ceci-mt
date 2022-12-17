using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface IEmailService
    {
        Task<ResultResponse> SendEmailAsync(EmailRequestDTO emailRequest);
    }
}
