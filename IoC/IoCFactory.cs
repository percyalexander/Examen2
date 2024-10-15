using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Web.Mvc;
using Negocio;
using Repositorio;
using Unity.AspNet.Mvc;

namespace IoC
{
    public static class IoCFactory
    {
        public static void RegistrarComponentes()
        {
            var container = new UnityContainer();

            container.RegisterType<IMovimientoRepository, MovimientoRepository>();
            container.RegisterType<IMovimientoNegocio, MovimientoNegocio>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
