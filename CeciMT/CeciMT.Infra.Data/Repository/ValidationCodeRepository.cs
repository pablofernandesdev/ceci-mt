using CeciMT.Domain.Entities;
using CeciMT.Domain.Interfaces.Repository;
using CeciMT.Infra.Data.Context;
using System.Diagnostics.CodeAnalysis;

namespace CeciMT.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class ValidationCodeRepository : BaseRepository<ValidationCode>, IValidationCodeRepository
    {
        public ValidationCodeRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
        }
    }
}
