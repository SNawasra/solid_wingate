using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wingateCSharp.Interfaces;

namespace wingateCSharp.Validation
{
    
    public class NotNullValidation : IValidator
    {
        private ILogger logger { get; set; }

        public NotNullValidation(ILogger logger)
        {
            if (logger == null)
            {
                throw new Exception("Logs can't be null");
            }
            this.logger = logger;
        }

        public bool Validator(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }
            else return true;
        }

        public bool Validator(wingateSchema value)
        {
            return Validator(value.CardholderFirstName);
        }
    }
}
