using System;

namespace ExtendableLogger.Loggers
{
    internal abstract class BaseLogger
    {
        internal abstract void Log(string message, Exception exception);

        internal virtual void Debug(string message, Exception exception)
        {
            Log(message, exception);
        }

        internal virtual void Error(string message, Exception exception)
        {
            Log(message, exception);
        }

        internal virtual void Fatal(string message, Exception exception)
        {
            Log(message, exception);
        }

        internal virtual void Info(string message, Exception exception)
        {
            Log(message, exception);
        }

        internal virtual void Trace(string message, Exception exception)
        {
            Log(message, exception);
        }

        internal virtual void Warn(string message, Exception exception)
        {
            Log(message, exception);
        }
    }
}
