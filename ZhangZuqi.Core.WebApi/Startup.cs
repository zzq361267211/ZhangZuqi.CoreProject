using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ZhangZuqi.Core.WebApi.Utility;

namespace ZhangZuqi.Core.WebApi
{
    /// <summary>
    /// Core项目到处都是依赖注入  ：IOC+DI
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 运行时 调用
        /// 执行且只执行一次
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // 译：当前方法在被 运行时 调用，使用这个方法把服务添加到 container 当中
        public void ConfigureServices(IServiceCollection services)
        {

            #region 注册swager服务
            services.AddSwaggerGen(m => m.SwaggerDoc("V1", new OpenApiInfo()
            {
                Title = "test",
                Version = "version-01",
                Description = "张祖琪Api学习"
            }));

            #endregion

            #region 注册服务
            services.AddSingleton<CustomActionFilterAttribute>();

            #endregion
            services.AddControllers();

            //全局注册 
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(CustomActionFilterAttribute));
            });

            services.AddCors(option =>

            option.AddPolicy("AllowCors", _build => _build.AllowAnyOrigin().AllowAnyMethod()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //使用中间件，必要时可自行添加

            #region 使用swager中间件
            app.UseSwagger();
            app.UseSwaggerUI(m =>
            {
                m.SwaggerEndpoint("/swagger/V1/swagger.json", "test1");
            });

             


            app.UseRouting();

            //跨域组件使用
            app.UseCors("AllowCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
    }
}
