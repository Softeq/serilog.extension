// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using Serilog;

namespace Softeq.Serilog.Extension
{
    public static class LogExtensions
    {
        [Obsolete("Use Event()... .AsDebug() instead", false)]
        public static void DebugEvent(this ILogger logger, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Debug(messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsDebug() instead", false)]
        public static void DebugEvent(this ILogger logger, Exception ex, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Debug(ex, messageTemplate, values);
        }


        [Obsolete("Use Event()... .AsInfo() instead", false)]
        public static void InformationEvent(this ILogger logger, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Information(messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsInfo() instead", false)]
        public static void InformationEvent(this ILogger logger, Exception ex, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Information(ex, messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsWarning() instead", false)]
        public static void WarningEvent(this ILogger logger, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Warning(messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsWarning() instead", false)]
        public static void WarningEvent(this ILogger logger, Exception ex, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Warning(ex, messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsError() instead", false)]
        public static void ErrorEvent(this ILogger logger, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Error(messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsError() instead", false)]
        public static void ErrorEvent(this ILogger logger, Exception ex, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Error(ex, messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsFatal() instead", false)]
        public static void FatalEvent(this ILogger logger, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Fatal(messageTemplate, values);
        }

        [Obsolete("Use Event()... .AsFatal() instead", false)]
        public static void FatalEvent(this ILogger logger, Exception ex, string eventId, string messageTemplate = "", params object[] values)
        {
            logger.WithEventId(eventId).Fatal(ex, messageTemplate, values);
        }


        [Obsolete("Use Event().With.Property()... instead", false)]
        public static ILogger With(this ILogger logger, string property, object value)
        {
            return logger.ForContext(property, value, true);
        }

        [Obsolete("Use Event(\"EventId\")... instead", false)]
        public static ILogger WithEventId(this ILogger logger, string eventId)
        {
            return logger.With(PropertyNames.EventId, eventId);
        }
    }
}
