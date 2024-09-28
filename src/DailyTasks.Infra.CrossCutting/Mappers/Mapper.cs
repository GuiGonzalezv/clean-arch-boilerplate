using AutoMapper;

namespace AgrotoolsMaps.Infra.CrossCutting.Mappers
{
    public class Mapper : Application.Interfaces.Mappers.IMapper
    {
        private readonly IMapper _mapper;
        public Mapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TResult Map<TResult>(object origin)
        {
            return _mapper.Map<TResult>(origin);
        }

        public TResult Map<TResult>(object origin, object context)
        {
            return _mapper.Map<TResult>(origin, opts => opts.Items["aditionalData"] = context);
        }
    }
}