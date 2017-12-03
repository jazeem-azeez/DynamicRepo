using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRepo.Common.ExceptionHandling
{
    class ExceptionBase:Exception
    {
        string ExCategory { get; set; }

        public ExceptionBase()
        {
            
        }
    }
}
