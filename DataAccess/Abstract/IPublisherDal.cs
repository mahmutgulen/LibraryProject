using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPublisherDal : IEntityRepository<Publisher>
    {
    }
}
