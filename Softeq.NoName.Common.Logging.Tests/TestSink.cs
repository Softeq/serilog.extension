// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace Softeq.NoName.Common.Logging.Tests
{
    public class TestSink : ILogEventSink
    {
        private readonly List<LogEvent> _logStorage;

        public TestSink(List<LogEvent> logStorage)
        {
            _logStorage = logStorage;
        }

        public void Emit(LogEvent logEvent)
        {
            _logStorage.Add(logEvent);
        }
    }
}
