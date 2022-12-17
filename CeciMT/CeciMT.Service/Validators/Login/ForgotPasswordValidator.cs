using CeciMT.Domain.DTO.Auth;
using CeciMT.Domain.Interfaces.Repository;
using FluentValidation;
using System.Threading.Tasks;

namespace CeciMT.Service.Validators.Login
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDTO>
    {
        private readonly IUnitOfWork _uow;

        public ForgotPasswordValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(c => c.Email)
                .EmailAddress()
                .MustAsync(async (email, cancellation) => {
                    return await RegisteredEmail(email);
                }).WithMessage("E-mail not found.");
        }

        private async Task<bool> RegisteredEmail(string email)
        {
            return await _uow.User.GetFirstOrDefaultAsync(x => x.Email.Equals(email)) != null;
        }
    }
}
