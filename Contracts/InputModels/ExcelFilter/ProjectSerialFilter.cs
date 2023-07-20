using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.ExcelFilter
{
    public class ProjectSerialFilter : IBaseExcel
    {
        public string ProcedureName { get; } = "Pharmacy_ExcelReport";

        public object filterObject { get; set; }
    }
}
