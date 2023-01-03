
using Autofac;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Repository.Repositories;
using Education.Repository.UnitOfWork;
using Education.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Education.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerMatchingLifetimeScope();
            //builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //var apiAssembly = Assembly.GetExecutingAssembly();

            //var repoAssembly = Assembly.GetAssembly(typeof(EducationDbContext));
            //var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            //    .Where(x => x.Value.EndsWith("RepositoryImp")).AsImplementedInterfaces().InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            // .Where(x => x.Value.EndsWith("ServiceImp")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<EducationServiceImp>().As<IEducationService>();
            //builder.RegisterType<EducationRepositoryImp>().As<IEducationRepository>();


        }
    }
}
