// Decompiled with JetBrains decompiler
// Type: Program
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/www/service/stockadmin/stockadmin.dll
using Microsoft.AspNetCore.HttpOverrides;
using NLog.Web;
using stockadmin;
using stockadmin.Internal;
using System.Runtime.InteropServices;
using NLog;

#nullable enable
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
NLog.SetupBuilderExtensions.GetCurrentClassLogger(NLog.Web.SetupBuilderExtensions.LoadConfigurationFromAppSettings(LogManager.Setup()));
builder.Logging.ClearProviders();

AspNetExtensions.UseNLog(builder.Host);
RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation(MvcServiceCollectionExtensions.AddMvc(builder.Services));
MvcServiceCollectionExtensions.AddControllersWithViews(builder.Services);
ConfigurationManager configuration = builder.Configuration;
DapperMysql.Init(ConfigurationBinder.GetValue<string>(configuration, "ConnectionStrings:WriteConnectionString"), ConfigurationBinder.GetValue<string>(configuration, "ConnectionStrings:ReadConnectionString"));
MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache(builder.Services);
SessionServiceCollectionExtensions.AddSession(builder.Services, (Action<SessionOptions>) (options =>
{
  options.Cookie.Name = "Session";
  options.IdleTimeout = TimeSpan.FromMinutes(60.0);
}));
OptionsServiceCollectionExtensions.Configure<CookiePolicyOptions>(builder.Services, (Action<CookiePolicyOptions>) (options =>
{
  options.CheckConsentNeeded = (Func<HttpContext, bool>) (context => true);
  options.MinimumSameSitePolicy = SameSiteMode.None;
}));
ServiceCollectionServiceExtensions.AddSingleton<SessionMiddleware>(builder.Services);
WebApplication webApplication = builder.Build();
if (!HostEnvironmentEnvExtensions.IsDevelopment(webApplication.Environment))
{
  ExceptionHandlerExtensions.UseExceptionHandler(webApplication, "/Home/Error");
  webApplication.Urls.Add("http://localhost:9014");
}
StaticFileExtensions.UseStaticFiles(webApplication);
EndpointRoutingApplicationBuilderExtensions.UseRouting(webApplication);
AuthorizationAppBuilderExtensions.UseAuthorization(webApplication);
SessionMiddlewareExtensions.UseSession(webApplication);
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
  ForwardedHeadersExtensions.UseForwardedHeaders(webApplication, new ForwardedHeadersOptions()
  {
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
  });
UseMiddlewareExtensions.UseMiddleware<SessionMiddleware>(webApplication);
Init.Run();
ControllerEndpointRouteBuilderExtensions.MapControllerRoute(webApplication, "default", "{controller=Login}/{action=Index}");
webApplication.Run();
