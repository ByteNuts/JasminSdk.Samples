using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ByteNuts.PrimaveraBss.JasminSdk.Core.Models;
using ByteNuts.PrimaveraBss.JasminSdk.Mvc;
using Serilog;

namespace ByteNuts.PrimaveraBss.JasminSdk.Samples.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Log created!!");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            JasminSdkConfig.UseJasminSdk(new JasminConfig
            {
                AccountKey = "",
                SubscriptionKey = "",
                ClientId = "",
                ClientSecret = ""
            });
        }
    }
}
