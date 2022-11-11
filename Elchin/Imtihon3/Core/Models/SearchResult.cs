using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtihon3.Core.Models
{
    public partial class Root
    {
        public class SearchResult
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int TotalResults { get; set; }
            public int TotalResultsVariants { get; set; }
            public List<Result> Results { get; set; }
        }
    }
}
