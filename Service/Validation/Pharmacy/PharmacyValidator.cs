using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Pharmacy
{
    public class PharmacyValidator : AbstractValidator<PharmacyInfo>
    {

        public PharmacyValidator()
        {

        }
    }
}

