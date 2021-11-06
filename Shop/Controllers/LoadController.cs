using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;

namespace FileUploadApp.Controllers
{
	public class LoadController : Controller
	{
		AppDbContext _context;
		IWebHostEnvironment _appEnvironment;

		public LoadController(AppDbContext context, IWebHostEnvironment appEnvironment)
		{
			_context = context;
			_appEnvironment = appEnvironment;
		}

		public IActionResult Index()
		{
			return View(_context.Cars.ToList());
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(LoadViewModel view)
		{
			if (view.File.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					view.File.CopyTo(ms);
					var fileBytes = ms.ToArray();

					Car car = new Car()
					{
						Name = view.Car.Name,
						Price = view.Car.Price,
						ShortDesc = view.Car.ShortDesc,
						Data = fileBytes,
						IsFavourite = view.Car.IsFavourite,
						// TODO: Сделать вычисление на форме или default в БД
						Availiable = true,
						Category = DbObjects.DbCategory(_context)["Электромобили"]
					};

					_context.Add(car);
					_context.SaveChanges();
				}
			}

			return RedirectToAction("Index");
		}
	}
}