using AgrotoolsMaps.Application.UseCases;

namespace AgrotoolsMaps.Application.Interfaces
{
    public interface IOutputPort
    {
        void Handle<T>(UseCaseOutput<T> output) where T : class;
    }
}