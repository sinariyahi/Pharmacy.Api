using Contracts.Dto.SystemNav.Users;
using Contracts.InputModels.DataEntryModels.Medicine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Medicine
{
    public class MedicineValidator : AbstractValidator<MedicineInfo>
    {

        public MedicineValidator()
        {

        }
    }
}

