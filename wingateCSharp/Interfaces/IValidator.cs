using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp.Interfaces
{
   public interface IValidator
    {
        bool Validator(string value);
        bool Validator(wingateSchema value);

    }
}
