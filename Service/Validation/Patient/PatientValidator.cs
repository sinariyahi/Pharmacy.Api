using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.DataEntryModels.Patient;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Patient
{
    public  class PatientValidator : AbstractValidator<PatientInfo>
    {

        public PatientValidator()
        {

        }
    }
}
