using Cinema.Dominio.Common;
using Cinema.IoC;
using Cinema.Web.Filters;

namespace Cinema.Web
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
            StartupIoc.ConfigureServices(services, Configuration);

            services.AddMvc(config => {
                config.Filters.Add(typeof(CustomExceptionFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            app.UseBrowserLink();
            app.UseRouting();
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}");
            });
        }
    }
}
