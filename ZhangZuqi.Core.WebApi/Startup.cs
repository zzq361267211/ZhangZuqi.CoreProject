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
    /// Core��Ŀ������������ע��  ��IOC+DI
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// ����ʱ ����
        /// ִ����ִֻ��һ��
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // �룺��ǰ�����ڱ� ����ʱ ���ã�ʹ����������ѷ�����ӵ� container ����
        public void ConfigureServices(IServiceCollection services)
        {

            #region ע��swager����
            services.AddSwaggerGen(m => m.SwaggerDoc("V1", new OpenApiInfo()
            {
                Title = "test",
                Version = "version-01",
                Description = "������Apiѧϰ"
            }));

            #endregion

            #region ע�����
            services.AddSingleton<CustomActionFilterAttribute>();

            #endregion
            services.AddControllers();

            //ȫ��ע�� 
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



            //ʹ���м������Ҫʱ���������

            #region ʹ��swager�м��
            app.UseSwagger();
            app.UseSwaggerUI(m =>
            {
                m.SwaggerEndpoint("/swagger/V1/swagger.json", "test1");
            });

             


            app.UseRouting();

            //�������ʹ��
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
