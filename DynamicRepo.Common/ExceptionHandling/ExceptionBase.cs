using System;

namespace DynamicRepo.Common.ExceptionHandling
{
    internal class ExceptionBase : Exception
    {
        private string ExCategory { get; set; }

        public ExceptionBase()
        {
        }
    }
}