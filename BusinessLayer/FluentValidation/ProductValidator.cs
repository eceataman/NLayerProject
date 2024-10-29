using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("ürün adını bos geçemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("ürün adı minimum 3 karakter olmalıdır");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("stok sayısı bos gecilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat bos gecilemez");
        
        }
    }
}
