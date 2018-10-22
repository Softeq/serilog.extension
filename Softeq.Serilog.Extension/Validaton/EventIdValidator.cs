// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.Serilog.Extension
{
    /// <summary>
    /// Performs validation of event id.
    /// </summary>
    public static class EventIdValidator
    {
        private static Func<string, bool> _validator;
        private static Action<string> _validationErrorHandler;

        /// <summary>
        /// Configures event id validator.
        /// </summary>
        /// <param name="eventIdValidator">Validation callback. Receives raw event id as a string argument.</param>
        /// <param name="onError">Callback that is called on validation error. Raw event id is passed as an argument.</param>
        public static void Configure(Func<string, bool> eventIdValidator, Action<string> onError)
        {
            _validator = eventIdValidator;
            _validationErrorHandler = onError;
        }

        internal static void Validate(string eventId)
        {
            if (_validator != null && _validationErrorHandler != null)
            {
                var isValidEventId = _validator(eventId);
                if (!isValidEventId)
                {
                    _validationErrorHandler(eventId);
                }
            }
        }
    }
}
