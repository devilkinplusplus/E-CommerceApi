using FluentValidation;
using ShopApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Validators.Products
{
    public class ProductCreateValidator:AbstractValidator<ProductCreateVM>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Məhsul adı boş buraxıla bilməz")
                    .MaximumLength(70).WithMessage("Maksimum karakter limiti aşıldı");

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Boş keçilə bilməz")
                            .MaximumLength(500).WithMessage("Maksimum karakter limiti aşıldı");

            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Qiymət boş keçilə bilməz")
                        .GreaterThanOrEqualTo(0).WithMessage("Qiymət mənfi ola bilməz");

            RuleFor(x => x.Stock).NotNull().NotEmpty().WithMessage("Stok sayı boş keçilə bilməz")
                    .GreaterThanOrEqualTo(0).WithMessage("Stok məlumatı mənfi ola bilməz");
        }
    }
}
