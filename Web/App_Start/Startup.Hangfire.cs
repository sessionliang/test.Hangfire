using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Redis;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
            //Hangfire+SqlServer(免费版)
            //GlobalConfiguration.Configuration.UseSqlServerStorage("<name or connection string>");
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();


            //Hangfire_net40+Redis(version:1.1.1)
            //app.UseHangfire(config =>
            //{
            //    config.UseRedisStorage("123123@127.0.0.1", 0, new Hangfire.Redis.RedisStorageOptions());
            //    config.UseServer();
            //});

            //Hangfire+Redis.StackExchange(免费版)
            GlobalConfiguration.Configuration.UseRedisStorage("localhost,password=123123", new Hangfire.Redis.RedisStorageOptions() {
               
            });
            app.UseHangfireDashboard();
            app.UseHangfireServer();

        }
    }
}