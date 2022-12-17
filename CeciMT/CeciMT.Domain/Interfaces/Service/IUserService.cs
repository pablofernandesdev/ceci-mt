﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.User;

namespace CeciMT.Domain.Interfaces.Service
{
    public interface IUserService 
    {
        Task<ResultDataResponse<IEnumerable<UserResultDTO>>> GetAsync(UserFilterDTO filter);
        Task<ResultResponse> AddAsync(UserAddDTO obj);
        Task<ResultResponse> DeleteAsync(UserDeleteDTO obj);
        Task<ResultResponse> UpdateAsync(UserUpdateDTO obj);
        Task<ResultResponse<UserResultDTO>> GetByIdAsync(int id);
        Task<ResultResponse> UpdateRoleAsync(UserUpdateRoleDTO obj);
    }
}
