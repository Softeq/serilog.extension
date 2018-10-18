// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using Softeq.NoName.Common.Logging;

namespace Softeq.NoName.Common.Logging
{
    /// <summary>
    /// Represents not configured event that canot be written to log.
    /// </summary>
    public interface IEventWithParameters
    {
        /// <summary>
        /// Writes event message.
        /// </summary>
        /// <param name="template">
        /// Message template describing the event. You can provide Serilog decorators inside message template.
        /// You can find more details about decorators <see href="https://github.com/serilog/serilog/wiki/Structured-Data">here</see>
        /// </param>
        /// <param name="parameters">Event parameters that are serialized using message template.</param>
        /// <returns>Configured log event.</returns>
        IWritableEventWithParameters Message(string template, params object[] parameters);

        /// <summary>
        /// Writes event entry property. This method should be used for implementation of custom extensions.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="value">Property value.</param>
        /// <returns>Configured log event.</returns>
        IWritableEventWithParameters Property(string name, object value);

        /// <summary>
        /// Writes exception data into <see cref="PropertyNames.DetailedException"/> message template property.
        /// </summary>
        /// <param name="exception">Exception insatnce.</param>
        /// <returns>Configured log event.</returns>
        IWritableEventWithParameters Exception(Exception exception);
    }
}