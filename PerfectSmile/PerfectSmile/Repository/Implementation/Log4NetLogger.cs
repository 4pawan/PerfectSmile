using log4net;
using PerfectSmile.EF;
using PerfectSmile.Repository.Abstract;
using Prism.Logging;

namespace PerfectSmile.Repository.Implementation
{
    public class Log4NetLogger : ILoggerFacade, ILog4NetLogger
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Log4NetLogger));

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    Debug(message);
                    break;
                case Category.Warn:
                    Warn(message);
                    break;
                case Category.Exception:
                    Exception(message);
                    break;
                case Category.Info:
                    Info(message);
                    break;
            }
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Exception(string message)
        {
            _logger.Error(message);
        }
    }
}
