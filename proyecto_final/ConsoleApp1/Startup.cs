using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;

namespace YourNamespace
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se llama en tiempo de ejecución. Usa este método para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar DbContext para usar SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Agregar soporte para controladores con vistas (MVC)
            services.AddControllersWithViews();
        }

        // Este método se llama en tiempo de ejecución. Usa este método para configurar el pipeline de la aplicación.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Configura la ruta por defecto de la aplicación
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Alumno}/{action=Index}/{id?}");
            });
        }
    }
}
