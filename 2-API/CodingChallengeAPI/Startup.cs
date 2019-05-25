﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CodingChallengePersistance;
using CodingChallengeBusiness.Interfaces;
using Microsoft.Extensions.FileProviders;
using System.IO;
using CodingChallengeAPI.Helpers;
using Microsoft.AspNetCore.Authentication;
using Business = CodingChallengeBusiness.Services;
using CodingChallengePersistance.Utilities;

namespace CodingChallengeAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                    .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddDirectoryBrowser();
            services.AddSingleton(Configuration);
            //Persitance DI  
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapUtility, MapUtility>();
            //Service DI (Business layer)
            services.AddScoped<Business.AuthenticationService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // configure basic authentication 
            services.AddAuthentication("Basic")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthentication>("Basic", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), Configuration["ApiSettings:MediaPath"])),
            })
            .UseCors(builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            )
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseMvc();
        }
    }
}
