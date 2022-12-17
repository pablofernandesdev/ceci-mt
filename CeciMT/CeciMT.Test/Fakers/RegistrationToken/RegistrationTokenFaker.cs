using Bogus;
using CeciMT.Test.Fakers.User;

namespace CeciMT.Test.Fakers.RegistrationToken
{
    public class RegistrationTokenFaker
    {
        public static Faker<CeciMT.Domain.Entities.RegistrationToken> RegistrationTokenEntity()
        {
            return new Faker<CeciMT.Domain.Entities.RegistrationToken>()
                .CustomInstantiator(p => new CeciMT.Domain.Entities.RegistrationToken
                {
                    Active = true,
                    UserId = p.Random.Int(),
                    Id = p.Random.Int(),
                    RegistrationDate = p.Date.Recent(),
                    Token = p.Random.String2(30),
                    User = UserFaker.UserEntity().Generate()
                });
        }
    }
}
