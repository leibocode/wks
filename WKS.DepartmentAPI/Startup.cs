using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MS.Cloud.AspNetCore.Extensions;
using MS.Cloud.AspNetCore.Middleware.Error;
using MS.Cloud.AutoMapper.Extensions;
using MS.Cloud.Core.DependencyInjection;
using MS.Cloud.SqlSugarCore.Extensions;
using MS.Cloud.SqlSugarCore.Options;
using MS.Cloud.Swagger.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static MS.Cloud.AspNetCore.Converters.SystemTextJsonConverter;

namespace WKS.DepartmentAPI
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
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new MS.Cloud.AspNetCore.Converters.SystemTextJsonConverter.DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
            });

            #region ×¢Èë¿ò¼Ü×é¼þ
            services.AddMsCloud(builder =>
            {
                builder.AddAspNetCore();
                builder.RegisterAllType();
                SugarFactoryOptions sugarOptions = builder.Configuration.GetSection("SqlSugar").Get<SugarFactoryOptions>();
                builder.Services.AddSqlSugar((Action<SugarFactoryOptions>)(options =>
                {
                    options.Configs = sugarOptions.Configs;
                    options.DefaultConfigId = sugarOptions.DefaultConfigId;
                    options.IsMultiple = sugarOptions.IsMultiple;
                    options.IsSqlAop = sugarOptions.IsSqlAop;
                }));
                builder.AddSwagger();
                builder.AddAutoMapper();
                builder.AddCors("any");
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("any");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAutoMapper();

            app.UseSwagger(Configuration);

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
