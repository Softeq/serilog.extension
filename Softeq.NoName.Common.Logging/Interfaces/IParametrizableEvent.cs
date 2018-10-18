// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.NoName.Common.Logging
{
    /// <summary>
    /// Represents entry that could be extended with extra data.
    /// </summary>
    public interface IParameterizableEvent : IWritableEvent
    {
        /// <summary>
        /// Allows addings extra parameters to event.
        /// </summary>
        IEventWithParameters With { get; }
    }
}