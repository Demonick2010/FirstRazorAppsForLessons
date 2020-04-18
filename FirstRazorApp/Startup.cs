using FirstRazorApp.AppRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstRazorApp
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
            // Добавляем сервис рэйзор-страниц
            services.AddRazorPages();

            // Подключаем сервис мок репоситория, связывая интерфейс и класс реализации
            services.AddSingleton<IEmpoyeeRepository, MockEmploeeRepository>();

            // Добавляем сервисы форматирования строки браузера
            // Переводим все символы запроса в нижний регистр
            services.Configure<RouteOptions>(options =>
            {
                // Переводит всю строку в нижний регистр
                options.LowercaseUrls = true;

                // Только запросы (передаваемые в строке параметры), например ID, NAME.. в нижний регистр
                options.LowercaseQueryStrings = false;

                // Добавить слэш после каждого параметра
                options.AppendTrailingSlash = true;

                // Добавляем ограничение которое мы задали в классе EvenConstraint
                options.ConstraintMap.Add("even", typeof(EvenConstraint));
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
