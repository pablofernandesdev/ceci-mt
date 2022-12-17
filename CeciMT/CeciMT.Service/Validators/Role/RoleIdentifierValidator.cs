using CeciMT.Domain.DTO.Role;
using CeciMT.Domain.Interfaces.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CeciMT.Service.Validators.Role
{
    public class RoleIdentifierValidator : AbstractValidator<IdentifierRoleDTO>
    {
        public RoleIdentifierValidator()
        {
            RuleFor(c => c.RoleId)
                .NotEmpty().WithMessage("Please enter the identifier role.")
                .NotNull().WithMessage("Please enter the identifier role.");
        }
    }
}
