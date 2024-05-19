using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Game.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.Filters;
using Game.Filter;
using Quartz;
using Quartz.Impl;
using Game.Design;
using NETCore.MailKit.Extensions;

namespace Game
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogHelper.Configure(); //使用前先配置
            Configuration = configuration;
            AllowHost = Configuration.GetValue<string>("AppSettings:AllowedOrgs");
            ConnectionString = Configuration.GetValue<string>("AppSettings:ConnectionString");
        }

        public IConfiguration Configuration { get; }
        public string AllowHost { get; set; }
        public static string ConnectionString { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddControllers(c =>
            {
                c.Filters.Add(new Filter.LogFilter());
                c.Filters.Add(new Filter.ExceptionFilter());
            });
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
           

            services.AddMvcCore().AddJsonOptions(opt =>
            {
                //此设定解决JsonResult中文被编码的问题
                //opt.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);

                opt.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                opt.JsonSerializerOptions.Converters.Add(new DateTimeNullableConvert());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "game", Version = "v1" });
                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //是否显示注释
                c.IncludeXmlComments(xmlPath, true);
            });
            services.AddCors(options =>
            {
                //options.AddPolicy("any", builder =>
                //{
                //    string[] splits = AllowHost.Split(',');
                //    builder.WithOrigins(splits).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                //});
                //                options.AddPolicy("any",
                //builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                options.AddPolicy("any",
builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });

            services.Configure<Model.EmailOptions>(Configuration.GetSection("EmailOptions"));
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new NETCore.MailKit.Infrastructure.Internal.MailKitOptions()
                {
                    //get options from sercets.json
                    Server = Configuration.GetValue<string>("EmailOptions:Host"),
                    Port = Configuration.GetValue<int>("EmailOptions:Port"),
                    SenderName = Configuration.GetValue<string>("EmailOptions:SenderName"),
                    SenderEmail = Configuration.GetValue<string>("EmailOptions:FromAddress"),

                    // can be optional with no authentication 
                    Account = Configuration.GetValue<string>("EmailOptions:UserName"),
                    Password = Configuration.GetValue<string>("EmailOptions:Password"),
                    // enable ssl or tls
                    Security = true
                });
            });


            services.AddSqlsugarSetup(Configuration, "AppSettings:ConnectionString");
            services.AddCSRedisSetup(Configuration, "AppSettings:RedisString");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddOptions();
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimit"));
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IAuthorizationFilter, CheCkMD5Filter>();
            //CheCkMD5Filter
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "game v1"));
            }
            app.UseCors("any");
            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
