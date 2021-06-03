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
            builder.RegisterType<HorarioViewModel>();
            builder.RegisterType<NuevaAsignaturaViewModel>();
            this.container = builder.Build();
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return this.container.Resolve<LoginViewModel>();
            }
        }

        public HorarioViewModel HorarioViewModel
        {
            get
            {
                return this.container.Resolve<HorarioViewModel>();
            }
        }

        public NuevaAsignaturaViewModel NuevaAsignaturaViewModel
        {
            get
            {
                return this.container.Resolve<NuevaAsignaturaViewModel>();
            }
        }
    }
}
