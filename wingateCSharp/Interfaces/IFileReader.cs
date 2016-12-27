using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp.Interfaces
{
    interface IFileReader
    {
        bool TrySplit(string values, out List<wingateSchema> data);
        // fake method
        bool TrySplit(out List<wingateSchema> data);
        bool TryRead(out string values);
    }

}
