using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Game2048;
using Microsoft.AspNetCore.Components.Builder;
using TimeCalculator;

namespace BlazorApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TimeService>();
            services.AddScoped((s) => GameManager.GetNewGame(4));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IComponentsApplicationBuilder components)
        {
            components.AddComponent<App>("app");
        }
    }
}