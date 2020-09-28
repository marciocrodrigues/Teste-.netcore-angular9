using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Paschoalotto.Api.Configuracoes;
using Paschoalotto.Infra.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Paschoalotto.Api
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
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.ResolverAutenticacao();
            services.AddSwaggerGen(options => swagger(options));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.ResolverDependecias();

        }

        private SwaggerGenOptions swagger(SwaggerGenOptions options)
        {

            options.SwaggerDoc("v1", new OpenApiInfo { Title = "PaschoalotoApi", Version = "v1" });

            OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
            {
                Name = "Bearer",
                BearerFormat = "JWT",
                Scheme = "bearer",
                Description = "Specify the authorization token.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
            };
            options.AddSecurityDefinition("jwt_auth", securityDefinition);

            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Id = "jwt_auth",
                    Type = ReferenceType.SecurityScheme
                }
            };

            OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
            {
                {securityScheme, new string[] { }},
            };

            options.AddSecurityRequirement(securityRequirements);


            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationName = PlatformServices.Default.Application.ApplicationName;
            var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

            if (File.Exists(xmlDocumentPath))
            {
                options.IncludeXmlComments(xmlDocumentPath);
            }

            return options;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "PaschoalotoApi");
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
