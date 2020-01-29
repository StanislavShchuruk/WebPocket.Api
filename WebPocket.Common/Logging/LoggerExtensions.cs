using Microsoft.Extensions.Logging;
using System;

namespace WebPocket.Common.Logging
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception ex)
        {
            logger.Log(LogLevel.Critical, new EventId(), ex.Message, ex, (s, e) => e.Message);
        }
    }
}
