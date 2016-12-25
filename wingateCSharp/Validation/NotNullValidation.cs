using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wingateCSharp.Interfaces;

namespace wingateCSharp.Validation
{
    class NotNullValidation : IValidator
    {
        public bool Validator(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }
            else return true;
        }
    }
}
