// Developed by Softeq Development Corporation
// http://www.softeq.com

using Serilog.Formatting.Display;

namespace Softeq.NoName.Common.Logging
{
    /// <summary>
    /// Commonly used log event placeholders for structured logging.
    /// </summary>
    public static class PropertyNames
    {
        /// <summary>
        /// Application name.
        /// </summary>
        public const string Application = "Application";

        /// <summary>
        /// Event timestamp.
        /// </summary>
        public const string Timestamp = OutputProperties.TimestampPropertyName;

        /// <summary>
        /// Event importance level.
        /// </summary>
        public const string Level = OutputProperties.LevelPropertyName;

        /// <summary>
        /// Event correlation id.
        /// </summary>
        public const string CorrelationId = "CorrelationId";

        /// <summary>
        /// Event message.
        /// </summary>
        public const string Message = OutputProperties.MessagePropertyName;

        /// <summary>
        /// Exception with a stack trace.
        /// </summary>
        public const string DetailedException = OutputProperties.ExceptionPropertyName;

        /// <summary>
        /// Serilog new line placeholder.
        /// </summary>
        public const string NewLine = OutputProperties.NewLinePropertyName;

        /// <summary>
        /// Event identifier placeholder.
        /// </summary>
        public const string EventId = "EventId";
    }
}
