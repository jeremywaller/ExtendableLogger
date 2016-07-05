using System;
using ExtendableLogger.Loggers;

namespace ExtendableLogger
{
    public interface ILogManager
    {
        void AddLogger(LoggerType loggerType, LogLevel logLevel, string name = "");

        void Trace(string message);
        void Trace(Exception exception);
        void Trace(string message, Exception exception);
        void Debug(string message);
        void Debug(Exception exception);
        void Debug(string message, Exception exception);
        void Info(string message);
        void Info(Exception exception);
        void Info(string message, Exception exception);
        void Warn(string message);
        void Warn(Exception exception);
        void Warn(string message, Exception exception);
        void Error(string message);
        void Error(Exception exception);
        void Error(string message, Exception exception);
        void Fatal(string message);
        void Fatal(Exception exception);
        void Fatal(string message, Exception exception);
    }
}
