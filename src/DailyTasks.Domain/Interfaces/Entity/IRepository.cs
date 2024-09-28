
using AgrotoolsMaps.Domain.Model.Entity;

namespace AgrotoolsMaps.Domain.Interfaces.Entity
{
    public interface IRepository<TDomainModel> where TDomainModel : DomainModel
    {
    }
}