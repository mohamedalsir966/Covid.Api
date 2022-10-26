using FluentValidation;
using Service.PatientFeatures.Commands;
using Service.PatientVaccinFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    
    public class CreatePatientVaccinCommandValidator : AbstractValidator<CreatePatientVaccinCommand>
    {
        public CreatePatientVaccinCommandValidator()
        {
            RuleFor(c => c.DoseNum).GreaterThanOrEqualTo(1);
        }
    }
}
