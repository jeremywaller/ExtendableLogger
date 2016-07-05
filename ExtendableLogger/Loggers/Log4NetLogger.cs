using System;
using log4net;

namespace ExtendableLogger.Loggers
{
    internal class Log4NetLogger : BaseLogger
    {
        private readonly ILog _log;

        public Log4NetLogger(string name)
        {
            _log = log4net.LogManager.GetLogger(name);
        }

        internal override void Trace(string message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        internal override void Debug(string message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        internal override void Info(string message, Exception exception)
        {
            _log.Info(message, exception);
        }

        internal override void Warn(string message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        internal override void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        internal override void Fatal(string message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        internal override void Log(string message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
