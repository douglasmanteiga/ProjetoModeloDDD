using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Infra.Data.Context;
using ProjetoModeloDDD.Infra.Data.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            //Lifestyle.Scoped = Uma instância por request
            container.Register<ProjetoModeloContext>(Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

        }
    }
}
