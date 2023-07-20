using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IDapperBaseRepository<T> where T : class
    {
        Task<(IEnumerable<T>, long)> GetAll(object parameters = null);
        Task<T> Get(object parameters = null);
        Task<T> GetById(long id);
        Task Insert(object parameters = null);
        Task Update(object parameters = null);
        Task Delete(object parameters = null);
        Task Delete(long id);
    }
}
