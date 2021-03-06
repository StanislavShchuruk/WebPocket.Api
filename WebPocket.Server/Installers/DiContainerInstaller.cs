﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPocket.Data.Entities.AuthEntities;
using WebPocket.Repo.DbContexts;
using WebPocket.Repo.UnitOfWork;
using WebPocket.Services.Impl;
using WebPocket.Services.Interfaces;

namespace WebPocket.Web.Installers
{
    public class DiContainerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPocketService, PocketService>();
        }
    }
}
