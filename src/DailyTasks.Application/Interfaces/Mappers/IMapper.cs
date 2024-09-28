namespace AgrotoolsMaps.Application.Interfaces.Mappers
{
    public interface IMapper
    {
        TResult Map<TResult>(object origin);
        TResult Map<TResult>(object origin, object context);

    }
}