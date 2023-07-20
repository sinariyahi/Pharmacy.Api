using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Personnel
{
    public class PersonnelFilterModel : BaseFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
}