// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Text;

namespace Softeq.Serilog.Extension
{
    public sealed class SerilogTemplateBuilder
    {
        private readonly string _propertySeparator;
        private readonly StringBuilder _templateBuilder;

        public SerilogTemplateBuilder() : this(" ")
        {
        }

        public SerilogTemplateBuilder(string propertySeparator)
        {
            _propertySeparator = propertySeparator;
            _templateBuilder = new StringBuilder();
        }

        public SerilogTemplateBuilder CorrelationId()
        {
            AddPlaceholder(FormatProperty(PropertyNames.CorrelationId));
            return this;
        }

        public SerilogTemplateBuilder EventId()
        {
            AddPlaceholder(FormatProperty(PropertyNames.EventId + ":l"));
            return this;
        }

        public SerilogTemplateBuilder Timestamp()
        {
            AddPlaceholder(FormatProperty($"{PropertyNames.Timestamp}:yyyy-MM-dd HH:mm:ss.fff"));
            return this;
        }

        public SerilogTemplateBuilder Message()
        {
            AddPlaceholder(FormatProperty(PropertyNames.Message));
            return this;
        }

        public SerilogTemplateBuilder Level()
        {
            AddPlaceholder(FormatProperty(PropertyNames.Level));
            return this;
        }

        public SerilogTemplateBuilder NewLine()
        {
            AddPlaceholder(FormatProperty(PropertyNames.NewLine));
            return this;
        }

        public SerilogTemplateBuilder Exception()
        {
            AddPlaceholder(FormatProperty(PropertyNames.DetailedException));
            return this;
        }

        public SerilogTemplateBuilder AddPlaceholder(string placeholder)
        {
            if (_templateBuilder.Length > 0)
            {
                _templateBuilder.Append(_propertySeparator);
            }

            _templateBuilder.Append(placeholder);

            return this;
        }

        public string Build()
        {
            return _templateBuilder.ToString();
        }

        private static string FormatProperty(string property)
        {
            return "{" + property + "}";
        }
    }
}
