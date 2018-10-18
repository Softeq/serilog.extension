// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Collections.Generic;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace Softeq.NoName.Common.Logging.Tests
{
    public static class TestSinkExtensions
    {
        public static LoggerConfiguration TestSink(this LoggerSinkConfiguration loggerConfiguration, List<LogEvent> logStorage)
        {
            return loggerConfiguration.Sink(new TestSink(logStorage));
        }
    }
}
