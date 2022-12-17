using CeciMT.Domain.DTO.User;
using CeciMT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface ITokenService
    {
        public string GenerateToken(UserResultDTO model);
    }
}
