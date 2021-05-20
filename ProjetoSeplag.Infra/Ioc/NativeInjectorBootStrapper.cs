using Microsoft.Extensions.DependencyInjection;
using ProjetoSeplag.Aplication.Updates.Services;
using ProjetoSeplag.Domain.Updates.Repository;
using ProjetoSeplag.Domain.Updates.Services;
using ProjetoSeplag.Infra.Data.Context;
using ProjetoSeplag.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjetoSeplag.Services.AutoMapper;
using ProjetoSeplag.Infra.Integration;

namespace ProjetoSeplag.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUpdateRepository, UpdateRepository>();
            services.AddScoped<IUpdateServices, UpdateServices>();
            //services.AddScoped<AplicationContext>();
            services.AddAutoMapper(typeof(UpdateMappingProfile));
            services.AddScoped<IIntegrationUpdates, IntegrationUpdates>();
        }


    }
}
