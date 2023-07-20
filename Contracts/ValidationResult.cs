using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ValidationResult
    {
        public ValidationResult(string _title, List<string> _errors)
        {
            this.Errors = _errors;
            this.Title = _title;
        }
        public string Title { get; set; }
        public List<string> Errors { get; set; }
    }
}
