// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.NoName.Common.Logging
{
    /// <summary>
    /// Represents configured event that can be written to log.
    /// </summary>
    public interface IWritableEventWithParameters : IEventWithParameters, IWritableEvent
    {
    }
}