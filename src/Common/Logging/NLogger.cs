using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using System;

namespace Common.Logging
{
    public class NLogger : ILogger
    {

        private readonly NLog.Logger _logger;


        public NLogger(IConfiguration config)
        {
            _logger = LogManager.GetCurrentClassLogger();
            ConfigLoggers(config);
        }

        /// <summary>
        /// Config logging
        /// </summary>
        /// <param name="settings"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ConfigLoggers(IConfiguration config)
        {
            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
        }


        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Debug(string message, Exception e)
        {
            _logger.Debug(message, e);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string message, Exception e)
        {
            _logger.Error(message, e);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception e)
        {
            _logger.Fatal(message, e);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string message, Exception e)
        {
            _logger.Info(message, e);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Trace(string message, Exception e)
        {
            _logger.Trace(message, e);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Warn(string message, Exception e)
        {
            _logger.Warn(message, e);
        }
    }
}
