using FluentValidation;
using PCP.Entities.Concrete;
using PCP.Entities.Concrete.Identity;
using PCP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Shared.FluentValidator.Validation
{
    public  class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz");
            RuleFor(u => u.EmailAddress).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
            //RuleFor(u => u.EmailAddress).NotEqual(u=>u.EmailAddress).WithMessage("Bu mail adresi ile başka bir kullanıcı bulunmaktadır!");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola boş bırakılamaz!");
            RuleFor(u => u.Password).Length(8, 20).WithMessage("Lütfen parolanızı en kısa 8,en uzun 20 karakter aralığında olacak şekilde belirleyiniz!!");
        }
    }
}
