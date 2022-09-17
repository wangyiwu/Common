using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Common.Logging
{
    public interface ILogger
    {
        void Trace(string message);
        void Trace(string message, Exception e);
        void Debug(string message);
        void Debug(string message, Exception e);
        void Info(string message);
        void Info(string message, Exception e);
        void Warn(string message);
        void Warn(string message, Exception e);
        void Error(string message);
        void Error(string message, Exception e);
        void Fatal(string message);
        void Fatal(string message, Exception e);
        void ConfigLoggers(IConfiguration config);
    }


    /// <summary>
    /// Logging setting
    /// </summary>
    public class LogSetting
    {
        public string Output { get; set; }
        public Level Level { get; set; }
        public string Layout { get; set; }

        public LogSetting(string output, Level level, string layout)
        {
            Output = output;
            Level = level;
            Layout = layout;
        }

        public LogSetting Clone() => new(Output, Level.Clone(), Layout);
    }

    /// <summary>
    /// Logging Level
    /// </summary>
    public class Level
    {
        public LogLevel Min { get; set; }
        public LogLevel Max { get; set; }

        public Level(LogLevel min, LogLevel max)
        {
            Min = min;
            Max = max;
        }

        public Level Clone() => new(Min, Max);
    }
}
