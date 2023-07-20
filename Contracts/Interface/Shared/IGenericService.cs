using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IGenericService<T, U>
    {
        Task<GSActionResult<IEnumerable<T>>> GetAll(BaseFilter filters);
        Task<GSActionResult<IEnumerable<T>>> GetAll(SimpleBaseFilter filters);
        Task<GSActionResult<IEnumerable<T>>> GetAllByCase(CaseSearchFilter filters);
        Task<GSActionResult<IEnumerable<T>>> GetAllByCaseWithUser(CaseSearchFilterWithUser filters);
        Task<GSActionResult<U>> GetInfo(dynamic id);
        Task<GSActionResult<object>> Save(object obj);
        Task<GSActionResult<object>> SaveNew(object obj);

    }
    public interface IGenericAttachmentService
    {
        string getAttachmentProcedure();
        string setAttachmentProcedure();
        string removeAttachmentProcedure();
    }

}
