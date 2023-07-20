using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Base
{
    public class BaseDataEntry<T>
    {
        public T Id { get; set; }
        public bool Include { get; set; }
        public Guid CreateBy { get; set; }
    }
}
