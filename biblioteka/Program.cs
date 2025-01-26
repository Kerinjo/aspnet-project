using biblioteka.Middleware;
using biblioteka.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace biblioteka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LibraryContext>();
            builder.Services.AddTransient<IMediaService, MediaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseMiddleware<LastVisitMiddleware>();
            app.Use(async (context, next) =>
            {

                var requestContent = new StringBuilder();
                requestContent.AppendLine("=== Request Info ===");
                requestContent.AppendLine($"method = {context.Request.Method.ToUpper()}");
                requestContent.AppendLine($"path = {context.Request.Path}");
                requestContent.AppendLine("-- headers");
                foreach (var (headerkey, headerValue) in context.Request.Headers)
                {

                    requestContent.AppendLine($"header = {headerkey} value = {headerValue}");
                }

                requestContent.AppendLine("-- body");
                context.Request.EnableBuffering();
                var requestReader = new StreamReader(context.Request.Body);
                var content = await requestReader.ReadToEndAsync();
                requestContent.AppendLine($"body = {content}");
                Console.Write(requestContent.ToString());
                context.Request.Body.Position = 0;
                await next();
            });

            app.Run();
        }
    }
}
