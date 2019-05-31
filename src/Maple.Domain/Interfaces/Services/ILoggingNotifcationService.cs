using System;

namespace Maple.Domain
{
    /// <summary>
    /// forwards user friendly messages to the UI and to a <see cref="ILoggingService"/>
    /// </summary>
    /// <autogeneratedoc />
    public interface ILoggingNotifcationService
    {
        void Info(string message);

        void Warn(string message);

        void Error(string message, Exception exception);

        void Fatal(string message, Exception exception);
    }
}
