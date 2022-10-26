using FluentValidation;
using Service.LookupFeaturs.Commands;
using Service.PatientVaccinFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
  
    public class CreateVaccinCommandValidator : AbstractValidator<CreateVaccinCommand>
    {
        public CreateVaccinCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.TotalNumOfDose).GreaterThanOrEqualTo(1);
        }
    }
}
