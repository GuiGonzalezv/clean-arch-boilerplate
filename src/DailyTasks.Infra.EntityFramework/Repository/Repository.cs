using AgrotoolsMaps.Application.Interfaces.Mappers;
using AgrotoolsMaps.Domain.Interfaces.Entity;
using AgrotoolsMaps.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace AgrotoolsMaps.Infra.EntityFramework.Repository
{
    public abstract class Repository<TContext, TDomainModel, TDataModel> : IRepository<TDomainModel>
        where TContext : DbContext
        where TDomainModel : DomainModel
        where TDataModel : DataModel.DataModel
    {
        private readonly IDbContextFactory<TContext> _contextFactory;

        protected Repository(IDbContextFactory<TContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            Mapper = mapper;
        }

        protected IMapper Mapper { get; }

        protected TContext ConfigureContext()
        {
            return _contextFactory.CreateDbContext();
        }
    }
}