using CRM.Application.Common.Mappings;
using CRM.Application.Interfaces;
using CRM.Persistence;
using System.Reflection;
using CRM.Application;
using CRM.WebApi.Middleware;

namespace CRM.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<CRMDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    // Логируем ошибку или делаем что-то с exception
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        // Настройка сервисов
                        services.AddAutoMapper(config =>
                        {
                            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                            config.AddProfile(new AssemblyMappingProfile(typeof(ICRMDbContext).Assembly));
                        });

                        services.AddApplication();
                        services.AddPersistence(context.Configuration);
                        services.AddControllers();

                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowAll", policy =>
                            {
                                policy.AllowAnyHeader();
                                policy.AllowAnyMethod();
                                policy.AllowAnyOrigin();
                            });
                        });
                    })
                    .Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        // Настройка конвейера HTTP-запросов
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        app.UseCustomExceptionHandler();
                        app.UseRouting();
                        app.UseHttpsRedirection();
                        app.UseCors("AllowAll");

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}