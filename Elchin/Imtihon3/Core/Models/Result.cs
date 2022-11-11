using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtihon3.Core.Models
{
    public partial class Root
    {
        public class Result
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Link { get; set; }
            public string Type { get; set; }
            public int Relevance { get; set; }
            public string Content { get; set; }
            public List<object> DataPoints { get; set; }
        }
    }
}
