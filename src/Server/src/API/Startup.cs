using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QueueManagementSystem.API.Middleware;
using QueueManagementSystem.API.ValidationFilter;
using QueueManagementSystem.Application.Validators;
using QueueManagementSystem.Infrastructure.IoC;

namespace QueueManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
                {
                    option.EnableEndpointRouting = false;
                    option.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(options =>
                    options.RegisterValidatorsFromAssemblyContaining<IBaseQuerymodelValidator>());

            services.AddCors();

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddHttpsRedirection(op => op.RedirectStatusCode = 307);
            services.RegisterServices(Configuration);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "QueueManagementSystem", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QueueManagementSystem v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}