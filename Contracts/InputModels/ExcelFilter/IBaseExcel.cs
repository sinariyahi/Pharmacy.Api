using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.ExcelFilter
{
    public interface IBaseExcel
    {
        string ProcedureName { get; }
        object filterObject { get; set; }
    }
    public class IBaseExcelFilter { }
}
