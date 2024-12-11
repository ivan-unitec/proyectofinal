using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Inicia la aplicación web
            CreateHostBuilder(args).Build().Run();
        }

        // Crea un constructor de host para la aplicación
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
