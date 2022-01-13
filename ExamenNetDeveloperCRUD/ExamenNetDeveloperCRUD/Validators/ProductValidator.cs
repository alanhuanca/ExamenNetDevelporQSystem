using ExamenNetDeveloperCRUD.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNetDeveloperCRUD.Validators
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(v => v.Nombre).NotEmpty().MinimumLength(5).MaximumLength(300);
            RuleFor(v => v.Precio).NotNull().GreaterThan(0);
            RuleFor(v => v.Stock).NotNull();
            RuleFor(v => v.FechaRegistro).NotNull();
        }
    }
}
