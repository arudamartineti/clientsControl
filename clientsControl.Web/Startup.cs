using AutoMapper;
using clientsControl.Application.Clients.Commands.CreateClient;
using clientsControl.Application.Clients.Commands.UpdateClient;
using clientsControl.Application.Clients.Queries.GetAllClients;
using clientsControl.Application.Infrastructure;
using clientsControl.Application.Infrastructure.AutoMapper;
using clientsControl.Application.Interfaces;
using clientsControl.Application.PaymentControls.Commands.CreatePaymentControl;
using clientsControl.Domain.Entities;
using clientsControl.Infrastructure.PaymentControl;
using clientsControl.Persistence;
using clientsControl.Web.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace clientsControl.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {                        
            // Automapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Solution Services
            services.AddTransient<IPaymentControlTool, PaymentControlTool>();

            // Autentication

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<clientsControlDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "yourdomain.com",
                        ValidAudience = "yourdomain.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dmFqOWiptiTHseLkXeLcdmFqOWiptiTHseLkXeLcdmFqOWiptiTHseLkXeLcdmFqOWiptiTHseLkXeLc")),
                        ClockSkew = TimeSpan.Zero
                    }
                );

            // MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetAllClientsQueryHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(CreatePaymentControlCommandHandler).GetTypeInfo().Assembly);



            // context
            services.AddDbContext<clientsControlDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("clientsControlDatabase")));
            

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))                
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => 
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateClientCommandValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateClientCommandValidator>();
                });

            //comportamiento para suprimir el ModelState
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
