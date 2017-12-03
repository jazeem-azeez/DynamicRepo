using System;

namespace DynamicRepo.Common.Logger
{
    public static class Logger
    {
        private static ILogger _logger;
        static Logger()
        {
            _logger = new LoggerForNlogger();
        }
    }
}
