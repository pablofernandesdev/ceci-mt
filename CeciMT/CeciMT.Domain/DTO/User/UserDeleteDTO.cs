using Microsoft.AspNetCore.Mvc;

namespace CeciMT.Domain.DTO.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDeleteDTO
    {
        /// <summary>
        /// Identifier user
        /// </summary>
        [BindProperty(Name = "userId")]
        public int UserId { get; set; }
    }
}
