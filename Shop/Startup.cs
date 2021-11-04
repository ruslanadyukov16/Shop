using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mokcs;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;

namespace Shop
{
	public class Startup
	{

		private IConfigurationRoot _connectionString;

		public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
		{
			_connectionString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_connectionString.GetConnectionString("DefaultConnection")));
			services.AddTransient<IAllCars, CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddTransient<IAllOrders, OrderRepository>();


			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShopCart.GetCart(sp));


			services.AddMvc(options => options.EnableEndpointRouting = false);

			services.AddMemoryCache();
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			// Для обращения к контроллеру Home
			//app.UseMvcWithDefaultRoute();
			app.UseMvc(routes =>
			{
				// По умолчанию контроллер = Home, Метод = Index
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}");
				routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
			});

			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				DbObjects.Initial(context);
			}
		}

	}
}
