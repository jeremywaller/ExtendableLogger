using System;
using System.Collections.Generic;
using System.Linq;
using ExtendableLogger.Loggers;

namespace ExtendableLogger
{
    public class LogManager : ILogManager
    {
        private readonly Dictionary<LogLevel, List<BaseLogger>> _loggers;

        public LogManager()
        {
            _loggers = new Dictionary<LogLevel, List<BaseLogger>>();

            LogLevel logLevel = LogLevel.All;
            foreach (LogLevel level in Enum.GetValues(logLevel.GetType()).Cast<LogLevel>())
            {
                _loggers.Add(level, new List<BaseLogger>());
            }

            log4net.Config.XmlConfigurator.Configure();
        }

        public void Trace(string message)
        {
            Trace(message, null);
        }

        public void Trace(Exception exception)
        {
            Trace(null, exception);
        }

        public void Trace(string message, Exception exception)
        {
            _loggers[LogLevel.Trace].ForEach(logger =>
            {
                logger.Trace(message, exception);
            });
        }

        public void Debug(string message)
        {
            Debug(message, null);
        }

        public void Debug(Exception exception)
        {
            Debug(null, exception);
        }

        public void Debug(string message, Exception exception)
        {
            _loggers[LogLevel.Debug].ForEach(logger =>
            {
                logger.Debug(message, exception);
            });
        }

        public void Info(string message)
        {
            Info(message, null);
        }

        public void Info(Exception exception)
        {
            Info(null, exception);
        }

        public void Info(string message, Exception exception)
        {
            _loggers[LogLevel.Info].ForEach(logger =>
            {
                logger.Info(message, exception);
            });
        }

        public void Warn(string message)
        {
            Warn(message, null);
        }

        public void Warn(Exception exception)
        {
            Warn(null, exception);
        }

        public void Warn(string message, Exception exception)
        {
            _loggers[LogLevel.Warn].ForEach(logger =>
            {
                logger.Warn(message, exception);
            });
        }

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(Exception exception)
        {
            Error(null, exception);
        }

        public void Error(string message, Exception exception)
        {
            _loggers[LogLevel.Error].ForEach(logger =>
            {
                logger.Error(message, exception);
            });
        }

        public void Fatal(string message)
        {
            Fatal(message, null);
        }

        public void Fatal(Exception exception)
        {
            Fatal(null, exception);
        }

        public void Fatal(string message, Exception exception)
        {
            _loggers[LogLevel.Fatal].ForEach(logger =>
            {
                logger.Fatal(message, exception);
            });
        }

        public void AddLogger(LoggerType loggerType, LogLevel logLevel, string name = "")
        {
            foreach (LogLevel value in Enum.GetValues(logLevel.GetType()).Cast<LogLevel>())
            {
                if (logLevel.HasFlag(value))
                {
                    switch (loggerType)
                    {
                        case LoggerType.Log4Net:
                            _loggers[value].Add(new Log4NetLogger(name));
                            break;
                    }
                }
            }
        }
    }
}
