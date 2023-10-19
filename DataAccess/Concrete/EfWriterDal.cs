using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer, LibraryContext>, IWriterDal
    {
    }
}
