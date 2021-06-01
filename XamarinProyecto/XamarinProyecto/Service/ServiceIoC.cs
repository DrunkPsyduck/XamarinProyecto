using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinProyecto.ViewModels;

namespace XamarinProyecto.Service
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        public void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceUsuarios>();
            builder.RegisterType<LoginViewModel>();
            this.container = builder.Build();
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return this.container.Resolve<LoginViewModel>();
            }
        }
    }
}
