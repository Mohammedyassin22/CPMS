using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorDetails
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
        public IEnumerable<string>? error { get;  set; }
    }
}
