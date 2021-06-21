using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using prosdocimus.Configuration;
using prosdocimus.Workers;

namespace prosdocimus
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        
        public Startup(IConfiguration confuguration)
        {
            Configuration = confuguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var options = new ProsdocimusOptions();

            Configuration.Bind("Prosdocimus", options);

            services.AddSingleton(options);

            services.AddHostedService<TwitterWorker>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
