using src.Filters.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public sealed class ODataModel : IODataContext
    {
        public string OrderBy { get; set; }
        public int Skip { get; set; }
        public int Top { get; set; }
    }
}
