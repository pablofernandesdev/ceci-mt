using CeciMT.Domain.DTO.Address;
using FluentValidation;

namespace CeciMT.Service.Validators.Address
{
    public class AddressIdentifierValidator : AbstractValidator<AddressIdentifierDTO>
    {
        public AddressIdentifierValidator()
        {
            RuleFor(c => c.AddressId)
                .NotEmpty().WithMessage("Please enter the address id.")
                .NotNull().WithMessage("Please enter the address id.");
        }
    }
}
