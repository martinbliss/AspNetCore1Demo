using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Filters.OData
{
    public sealed class ODataSettings : IODataContext
    {
        public string OrderBy { get; set; }
        public int Skip { get; set; }
        public int Top { get; set; }

        
    }
}
