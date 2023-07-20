using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IGenericRepository<T,U> where T : class
    {
        Task<(IEnumerable<T>, long)> GetAll(string spName, object parameters = null);
        Task<IEnumerable<T>> GetAllSingle(string spName, object parameters = null);
        Task<List<object>> GetMultiSelect(string spName, short outputCounts, object parameters = null);
        Task<U> Get(string spName, object parameters = null);
        Task<U> GetById(string spName, long id);
        Task<object> Insert(string spName, object parameters = null);
        Task Update(string spName, object parameters = null);
        Task Delete(string spName, object parameters = null);
        Task Delete(string spName, long id);
        Task<DataTable> GetDataTable(string spName, object parameters = null);
        Task<object> InsertWithTran(string spName, object parameters = null);

    }
}
