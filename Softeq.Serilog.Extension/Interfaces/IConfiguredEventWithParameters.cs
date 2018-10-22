// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.Serilog.Extension
{
    /// <summary>
    /// Represents configured event that can be written to log.
    /// </summary>
    public interface IWritableEventWithParameters : IEventWithParameters, IWritableEvent
    {
    }
}