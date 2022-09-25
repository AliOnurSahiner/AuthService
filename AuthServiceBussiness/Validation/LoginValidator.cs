using AuthServices.Models.Request;
using AuthServicesDAL.Entities.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServiceBussiness.Validation
{
    public class LoginValidator:AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Emaili boş bırakamazsınız!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Passwordu boş bırakamazsınız!");
            RuleFor(x => x.Email).Length(10, 50);
            RuleFor(x => x.Email).Must(ContainsWith).WithMessage("Geçerli bir EMail Formatı Girmediniz!");
        }

        private bool ContainsWith(string arg)
        {
            return arg.Contains("@");
        }
    }
}
