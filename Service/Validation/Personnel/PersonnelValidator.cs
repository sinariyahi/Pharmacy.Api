using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Personnel
{
    public class PersonnelValidator : AbstractValidator<PersonnelInfo>
    {

        public PersonnelValidator()
        {

        }
    }
}
