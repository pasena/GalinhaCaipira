using Castle.MicroKernel.Registration;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalinhaCaipira.MVC.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("GalinhaCaipira.Repositories")
                .Where(w => w.Name.EndsWith("Repository"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}