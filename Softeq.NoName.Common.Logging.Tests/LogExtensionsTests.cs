// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Serilog;
using Serilog.Events;
using Xunit;

namespace Softeq.NoName.Common.Logging.Tests
{
    public class LogExtensionsTests
    {
        [Fact]
        public void ShouldWriteEntryWithEventId()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            const string eventId = "TestEvent";
            logger.Event(eventId).AsInformation();

            var logEntry = eventStorage.First();
            logEntry.Properties.Should().Contain(p => p.Key == PropertyNames.EventId &&
                                                      p.Value is ScalarValue &&
                                                      p.Value.As<ScalarValue>().Value == eventId);
        }

        [Fact]
        public void ShouldValidateEventId()
        {
            ILogger logger = CreateLogger(new List<LogEvent>());
            bool isOnErrorHandlerCalled = false;
            const string invalidEventId = "event id with spaces";

            // WARNING! EventIdValidator::Configure is changing state of static validator and should be reset.
            try
            {
                EventIdValidator.Configure(eventId => !eventId.Contains(' '),
                                           eventId => isOnErrorHandlerCalled = true);

                logger.Event(invalidEventId).AsInformation();
            }
            finally
            {
                EventIdValidator.Configure(eventId => true, eventId => { });
            }

            isOnErrorHandlerCalled.Should().BeTrue();
        }

        [Fact]
        public void ShouldWriteEntryWithException()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            var expectedException = new Exception("Test exception");
            logger.Event("EventId").With.Exception(expectedException).AsInformation();

            var logEntry = eventStorage.First();
            logEntry.Exception.Should().Be(expectedException);
        }

        [Fact]
        public void ShouldWriteEventWithProperty()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            const string expectedPropertyName = "TestPropertyName";
            const int expectedPropertyValue = 1000;
            logger.Event("EventId").With.Property(expectedPropertyName, expectedPropertyValue).AsInformation();

            var logEntry = eventStorage.First();
            logEntry.Properties.Should().Contain(p => p.Key == expectedPropertyName &&
                                                      p.Value is ScalarValue &&
                                                      p.Value.As<ScalarValue>().Value.As<int>() == expectedPropertyValue);
        }

        [Fact]
        public void ShouldWriteEventWithMessage()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            const string messageTemplate = "This is test message template with {Parameter}";
            var testParameterValue = "test value";

            logger.Event("EventId").With.Message(messageTemplate, testParameterValue, testParameterValue).AsInformation();

            var logEntry = eventStorage.First();
            logEntry.MessageTemplate.Text.Should().Be(messageTemplate);
            logEntry.Properties.Should().Contain(p => p.Value is ScalarValue &&
                                                      p.Value.As<ScalarValue>().Value == testParameterValue);
        }

        [Fact]
        public void ShouldWriteDebugEvent()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            logger.Event("EventId").AsDebug();

            var logEntry = eventStorage.First();
            logEntry.Level.Should().Be(LogEventLevel.Debug);
        }

        [Fact]
        public void ShouldWriteInformationEvent()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            logger.Event("EventId").AsInformation();

            var logEntry = eventStorage.First();
            logEntry.Level.Should().Be(LogEventLevel.Information);
        }

        [Fact]
        public void ShouldWriteWarningEvent()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            logger.Event("EventId").AsWarning();

            var logEntry = eventStorage.First();
            logEntry.Level.Should().Be(LogEventLevel.Warning);
        }

        [Fact]
        public void ShouldWriteErrorEvent()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            logger.Event("EventId").AsError();

            var logEntry = eventStorage.First();
            logEntry.Level.Should().Be(LogEventLevel.Error);
        }

        [Fact]
        public void ShouldWriteFatalEvent()
        {
            var eventStorage = new List<LogEvent>();
            ILogger logger = CreateLogger(eventStorage);

            logger.Event("EventId").AsFatal();

            var logEntry = eventStorage.First();
            logEntry.Level.Should().Be(LogEventLevel.Fatal);
        }

        private static ILogger CreateLogger(List<LogEvent> eventStorage)
        {
            var logger = new LoggerConfiguration().MinimumLevel.Debug()
                                                  .WriteTo.TestSink(eventStorage)
                                                  .CreateLogger();

            return logger;
        }
    }
}
