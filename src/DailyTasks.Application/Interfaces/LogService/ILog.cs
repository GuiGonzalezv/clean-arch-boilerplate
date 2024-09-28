using AgrotoolsMaps.Domain.Model;

namespace AgrotoolsMaps.Application.Interfaces.LogService
{
    public interface ILog<T>
    {
        void Trace(string message);

        void Info(object obj);
        void History(TargetHistoryModel targetHistoryModel);

        void Warning(Exception exception, object obj);

        void Error(Exception exception, object obj);
    }
}