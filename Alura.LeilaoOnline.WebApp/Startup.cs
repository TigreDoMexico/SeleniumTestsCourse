using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Contratos;
using Alura.LeilaoOnline.WebApp.Configuracoes;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.LeilaoOnline.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration cfg)
        {
            Configuration = cfg;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseDependency(Configuration);

            services.AddDependencies();

            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}
