using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelManager.Repositories;
using TravelManager.Repositories.Impl;
using TravelManager.Services;
using TravelManager.Services.Impl;

namespace TravelManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectiString = Configuration.GetSection("ConnectionString").Value;

            services.AddSingleton<IConnectionProvider>(new ConnectionProvider(connectiString));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPacoteTuristicoRepository, PacoteTuristicoRepository>();
            services.AddTransient<ICadastroUsuarioServices, CadastroUsuarioServices>();
            services.AddTransient<ICadastroPacoteTuristicoServices, CadastroPacoteTuristicoServices>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
