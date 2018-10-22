// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using Serilog;
using Serilog.Events;
using Softeq.Serilog.Extension;

namespace Softeq.Serilog.Extension
{
    public struct LogEventEntryBuilder : IWritableEventWithParameters, IParameterizableEvent
    {
        private ILogger _logger;
        private string _messageTemplate;
        private object[] _messageParameters;
        private Exception _exception;

        internal LogEventEntryBuilder(ILogger logger)
        {
            _logger = logger;
            _exception = null;
            _messageTemplate = string.Empty;
            _messageParameters = null;
        }

        IEventWithParameters IParameterizableEvent.With => this;

        public IWritableEventWithParameters Message(string template, params object[] parameters)
        {
            _messageTemplate = template;
            _messageParameters = parameters;

            return this;
        }

        public IWritableEventWithParameters Property(string name, object value)
        {
            _logger = _logger.ForContext(name, value);
            return this;
        }

        public IWritableEventWithParameters Exception(Exception exception)
        {
            _exception = exception;
            return this;
        }


        void IWritableEvent.AsDebug()
        {
            Write(LogEventLevel.Debug);
        }

        void IWritableEvent.AsInformation()
        {
            Write(LogEventLevel.Information);
        }

        void IWritableEvent.AsWarning()
        {
            Write(LogEventLevel.Warning);
        }

        void IWritableEvent.AsError()
        {
            Write(LogEventLevel.Error);
        }

        void IWritableEvent.AsFatal()
        {
            Write(LogEventLevel.Fatal);
        }


        private void Write(LogEventLevel severity)
        {
            _logger.Write(severity, _exception, _messageTemplate, _messageParameters);
        }
    }
}
