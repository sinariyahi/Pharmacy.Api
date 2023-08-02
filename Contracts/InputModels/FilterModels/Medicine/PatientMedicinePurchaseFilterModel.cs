using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Medicine
{
    public class PatientMedicinePurchaseFilterModel : BaseFilter
    {
        public string PatientName { get; set; }
    }
}
