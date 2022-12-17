using CeciMT.Domain.DTO.Address;
using FluentValidation;

namespace CeciMT.Service.Validators.Address
{
    public class AddressZipCodeValidator : AbstractValidator<AddressZipCodeDTO>
    {
        public AddressZipCodeValidator()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("Please enter the zip code.")
                .NotNull().WithMessage("Please enter the zip code.");
        }
    }
}
