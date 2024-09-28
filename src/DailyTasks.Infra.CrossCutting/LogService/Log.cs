using AgrotoolsMaps.Application.Interfaces.LogService;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using Microsoft.Extensions.Configuration;
using AgrotoolsMaps.Domain.Model;
using System.Text.Json;


namespace AgrotoolsMaps.Infra.CrossCutting.LogService
{
    public class Log<T> : ILog<T>

    {
        private readonly ILogger<T> _logger;
        private readonly IConfiguration _configuration;

        public Log(ILogger<T> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Trace(string message)
        {
                _logger.LogTrace(message);
        }

        public void Info(object obj)
        {
            using (LogContext.PushProperty("log_data", JsonSerializer.Serialize(obj).Replace("\\", "")))
                _logger.LogInformation("{@obj}", obj);
        }

        public void Warning(Exception exception, object obj)
        {
            using (LogContext.PushProperty("log_data", JsonSerializer.Serialize(obj).Replace("\\", "")))
                _logger.LogWarning(exception, "{@obj}", obj);
        }

        public void Error(Exception exception, object obj)
        {
            using (LogContext.PushProperty("log_data", JsonSerializer.Serialize(obj).Replace("\\", "")))
                _logger.LogError(exception.Message);
        }

        public void History(TargetHistoryModel targetHistoryModel)
        {
            CreateHistoryLogFile($"{targetHistoryModel.TargetId}-{String.Format("{0:yyyy_MM_dd_HH_mm_ss}", DateTime.UtcNow)}.txt", targetHistoryModel.Object);

            using (LogContext.PushProperty("log_data", JsonSerializer.Serialize(targetHistoryModel.Object).Replace("\\", "")))
                _logger.LogInformation(targetHistoryModel.Message);
        }
        private void CreateHistoryLogFile(string fileName, object log)
        {
            string path = _configuration["AppSettings:HISTORY_LOG_PATH"] + fileName;
            File.AppendAllText(path, $"{log}; {Environment.NewLine}");
        }
    }
}