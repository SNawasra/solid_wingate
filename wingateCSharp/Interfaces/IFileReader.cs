using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp.Interfaces
{
   public interface IFileReader
    {
        bool TrySplit(string values, out List<wingateSchema> data);
        // fake method
        bool TrySplit(out List<wingateSchema> data);
        bool TryRead(out string values);
    }
    public class FileReader : IFileReader
    {
        public bool TryRead(out string values)
        {
            throw new NotImplementedException();
        }

        public virtual bool TrySplit(out List<wingateSchema> data)
        {
            throw new NotImplementedException();
        }

        public bool TrySplit(string values, out List<wingateSchema> data)
        {
            throw new NotImplementedException();
        }
    }

}
