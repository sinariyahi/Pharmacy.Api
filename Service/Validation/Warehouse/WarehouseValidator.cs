using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.DataEntryModels.Warehouse;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Warehouse
{
    public class WarehouseValidator : AbstractValidator<WarehouseInfo>
    {

        public WarehouseValidator()
        {

        }
    }
}