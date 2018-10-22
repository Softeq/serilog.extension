// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.Serilog.Extension
{
    public interface IWritableEvent
    {
        /// <summary>
        /// Writes log entry as debug event.
        /// </summary>
        void AsDebug();

        /// <summary>
        /// Writes log entry as information event.
        /// </summary>
        void AsInformation();

        /// <summary>
        /// Writes log entry as warning event.
        /// </summary>
        void AsWarning();

        /// <summary>
        /// Writes log entry as error event.
        /// </summary>
        void AsError();

        /// <summary>
        /// Writes log entry as fatal event.
        /// </summary>
        void AsFatal();
    }
}