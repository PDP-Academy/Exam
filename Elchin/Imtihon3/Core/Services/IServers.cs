using Imtihon3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtihon3.Core.Services
{
    public interface IServers
    {
        List<Root.SearchResult> ConvertObjectToJson(string foodName);
    }
}
