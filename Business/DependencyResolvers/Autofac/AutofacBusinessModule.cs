using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TurkishEventManager>().As<ITurkishEventService>();
            builder.RegisterType<EfTurkishEventDal>().As<ITurkishEventDal>();

            builder.RegisterType<ItalianEventManager>().As<IItalianEventService>();
            builder.RegisterType<EfItalianEventDal>().As<IItalianEventDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManeger>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}
