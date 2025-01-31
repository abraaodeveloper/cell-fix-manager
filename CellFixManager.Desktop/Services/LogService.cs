using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace CellFixManager.Desktop.Services
{
    public static class LogService
    {
        private static readonly ILogger _logger;

        static LogService()
        {
            var logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CellFixManager",
                "logs",
                "log-.txt");

            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .WriteTo.Console(
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(logPath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {ThreadId} {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            _logger.Information("Aplicação iniciada");
        }

        public static void Debug(string message, Exception? ex = null) =>
            _logger.Debug(ex, message);

        public static void Info(string message, Exception? ex = null) =>
            _logger.Information(ex, message);

        public static void Warn(string message, Exception? ex = null) =>
            _logger.Warning(ex, message);

        public static void Error(string message, Exception ex) =>
            _logger.Error(ex, message);

        public static void Fatal(string message, Exception ex) =>
            _logger.Fatal(ex, message);
    }
} 