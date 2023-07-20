using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Base
{
    public class BaseFilter
    {
        public bool IsAsc { get; set; }
        public string SortColumn { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class SimpleBaseFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class CaseSearchFilter : BaseFilter
    {
        public short SearchBy { get; set; }
        public string Value { get; set; }
    }
    public class CaseSearchFilterWithUser : CaseSearchFilter
    {
        public Guid UserId { get; set; }
    }
}
