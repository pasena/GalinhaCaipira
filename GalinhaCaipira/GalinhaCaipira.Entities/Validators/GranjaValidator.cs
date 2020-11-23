using FluentValidation;
using GalinhaCaipira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public class GranjaValidator : AbstractValidator<Granja>
    {
        public GranjaValidator()
        {
            RuleFor(r => r.NomeFantasia).SetValidator(new NomeFantasiaValidator());
        }
    }
}
