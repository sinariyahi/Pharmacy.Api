using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Base
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
    }
}
