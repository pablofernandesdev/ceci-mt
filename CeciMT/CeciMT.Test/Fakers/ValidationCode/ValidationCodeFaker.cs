using Bogus;
using CeciMT.Domain.DTO.ValidationCode;
using CeciMT.Infra.CrossCutting.Extensions;
using CeciMT.Test.Fakers.User;

namespace CeciMT.Test.Fakers.ValidationCode
{
    public class ValidationCodeFaker
    {
        public static Faker<CeciMT.Domain.Entities.ValidationCode> ValidationCodeEntity()
        {
            return new Faker<CeciMT.Domain.Entities.ValidationCode>()
                .CustomInstantiator(p => new CeciMT.Domain.Entities.ValidationCode
                {
                    UserId = p.Random.Int(),
                    Active = true,
                    Code = PasswordExtension.EncryptPassword(p.Random.Word()),
                    Expires = p.Date.Future(),
                    Id = p.Random.Int(),
                    RegistrationDate = p.Date.Recent(),
                    User = UserFaker.UserEntity().Generate()               
                });
        }

        public static Faker<ValidationCodeValidateDTO> ValidationCodeValidateDTO()
        {
            return new Faker<ValidationCodeValidateDTO>()
                .CustomInstantiator(p => new ValidationCodeValidateDTO
                {
                    Code = p.Random.Word()
                });
        }
    }
}
