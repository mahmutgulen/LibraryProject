using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfBookDal>().As<IBookDal>();

            builder.RegisterType<EfUsersBorrowedBookDal>().As<IUsersBorrowedBookDal>();

            builder.RegisterType<BusinessPanelManager>().As<IBusinessPanelService>();

            builder.RegisterType<EfBannedUserDal>().As<IBannedUserDal>();

            builder.RegisterType<BannedUserManager>().As<IBannedUserService>();

            builder.RegisterType<UnnecessaryInfosManager>().As<IUnnecessaryInfosService>();

            builder.RegisterType<EfWriterDal>().As<IWriterDal>();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>();
        }
    }
}
