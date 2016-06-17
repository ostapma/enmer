using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnmerCore.Exceptions
{
    public class LoggingSourceCodeException:Exception
    {
        public LoggingSourceCodeException():base("Logging source code should be unique")
        {
            
        }
    }
}
