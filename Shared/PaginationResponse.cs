using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared
{
    public class PaginationResponse<TENtity,TSpec>
    {
        public PaginationResponse(TSpec specvehicle, int pageindex, int pagesize, int totalcount, IEnumerable<TENtity> data)
        {
            PageIndex = pageindex;
            PageSize = pagesize;
            TotalCount = totalcount;
            Data = data;
        }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<TENtity> Data { get; set; }
    }
}
