using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ZoneSpecificationParameter
    {
        public string? zone { get; set; }
        public string? search { get; set; }
        public string? sort { get; set; }
        private int _indexPage = 1;
        private int _pageSize = 20;
        public int IndexPage
        {
            get => _indexPage;
            set => _indexPage = value < 1 ? 1 : value;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? 20 : value > 100 ? 100 : value;
        }
    }
}
