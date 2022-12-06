using Microsoft.EntityFrameworkCore;
using Mvc1.Infrastructure.Data;

namespace Mvc1
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment Environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connection = Configuration.GetConnectionString("Database");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        }

        public void Configure(IApplicationBuilder app)
        {
            if (!Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
           
            app.SeedData();
        }
    }
}
