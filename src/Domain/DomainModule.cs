using Aspect.Core;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Domain.Contracts;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class DomainModule:Module
  {


    protected override void Load(ContainerBuilder builder)
    {
      // servis registeration
      builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();

      // Interceptor için 

      builder.RegisterType<AccountService>().As<IAccountService>()
        .AsImplementedInterfaces()
        .EnableInterfaceInterceptors()
        .InterceptedBy(typeof(LogPerformaceAspect));

      // AccountService çağırıldığında LogPerformaceAspect çalışacak
    }
  }
}
