// Developed by Softeq Development Corporation
// http://www.softeq.com

using Serilog;

namespace Softeq.NoName.Common.Logging
{
    public static class LoggerExtensions
    {
        /// <summary>
        /// Starts initialization of log entry.
        /// </summary>
        /// <param name="logger">Serilog logger instance.</param>
        /// <param name="eventId">Event identifier, used for event search. </param>
        /// <returns></returns>
        public static IParameterizableEvent Event(this ILogger logger, string eventId)
        {
            EventIdValidator.Validate(eventId);

            var loggerWithEventId = logger.ForContext("EventId", eventId);
            return new LogEventEntryBuilder(loggerWithEventId);
        }
    }
}
