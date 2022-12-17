using CeciMT.Domain.Entities;
using CeciMT.Domain.Interfaces.Repository;
using CeciMT.Infra.Data.Context;
using System.Diagnostics.CodeAnalysis;

namespace CeciMT.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
        }
    }
}
