using FluentValidation;
using PCP.Entities.Concrete;
using PCP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Shared.FluentValidator.Validation
{
    public  class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz!");
        }
    }
}
