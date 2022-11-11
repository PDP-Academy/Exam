using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtihon3.Core.Brokers.File
{
    public interface IFile
    {
        void WriteToFIle(string data);

        string ReadToFile();
    }
}
