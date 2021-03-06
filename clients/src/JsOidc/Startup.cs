using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace JsOidc
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
                        services.AddCors(options =>
                        {
                            options.AddPolicy(name: MyAllowSpecificOrigins,
                                              builder =>
                                              {
                                                  builder.WithOrigins("http://localhost:9090/",
                                                      "https://localhost:9090/",
                                                      "https://demo.identity.subless.com/",
                                                      "http://ec2co-ecsel-f17xbspr0h75-664147277.us-east-1.elb.amazonaws.com:8080/");
                                              });
                        });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();


            // enable to test w/ CSP
            //app.Use(async (ctx, next) =>
            //{
            //    ctx.Response.OnStarting(() =>
            //    {
            //        if (ctx.Response.ContentType?.StartsWith("text/html") == true)
            //        {
            //            ctx.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; connect-src http://localhost:5000 http://localhost:3721; frame-src 'self' http://localhost:5000");
            //        }
            //        return Task.CompletedTask;
            //    });

            //    await next();
            //});

            app.UseStaticFiles();
            app.UseCors(MyAllowSpecificOrigins);

        }
    }
}