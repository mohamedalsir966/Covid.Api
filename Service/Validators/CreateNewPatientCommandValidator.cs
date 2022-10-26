using FluentValidation;
using Service.PatientFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class CreateNewPatientCommandValidator: AbstractValidator<CreateNewPatientCommand>
    {
        public CreateNewPatientCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
