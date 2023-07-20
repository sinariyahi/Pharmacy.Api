using Contracts.InputModels.ExcelFilter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IExcelService
    {
        Task<GSActionResult<object>> Import(string filePath, string moduleName, Guid currentUser);
        Task<DataTable> Export(IBaseExcel excelObj);
    }
}
