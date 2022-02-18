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
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı alanı boş bırakılamaz!");
            RuleFor(p => p.Name).MaximumLength(100).WithMessage("Ürün adı alanı maksimum 100 karakter olmalıdır!"); 
            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün açıklama alanı boş bırakılamaz!");
            RuleFor(p => p.Description).MaximumLength(100).WithMessage("Ürün açıklama alanı maksimum 500 karakter olmalıdır!"); 
        }
    }
}
