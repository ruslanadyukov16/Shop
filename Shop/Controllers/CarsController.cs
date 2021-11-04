using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;
using Shop.Data.Models;

namespace Shop.Controllers
{
	public class CarsController : Controller
	{
		private readonly IAllCars _allCars;
		private readonly ICarsCategory _allCategories;

		public CarsController(IAllCars allCars, ICarsCategory allCategories)
		{
			_allCars = allCars;
			_allCategories = allCategories;
		}

		[Route("Cars/List")]
		[Route("Cars/List/{category}")]
		public ViewResult List(string category)
		{
			string _category = category;
			IEnumerable<Car> cars = new List<Car>();
			string currCategory = "";

			if(string.IsNullOrEmpty(category))
			{
				cars = _allCars.Cars.OrderBy(c => c.Id);
			}
			else
			{
				if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(c => c.Category.CategoryName == "Электромобили").OrderBy(c => c.Id);
					currCategory = "Электромобили";
				}
				else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
				{
					cars = _allCars.Cars.Where(c => c.Category.CategoryName == "Классические автомобили").OrderBy(c => c.Id);
					currCategory = "Классические автомобили";
				}
				currCategory = _category;
			}


			var carObj = new CarsListViewModel
			{
				AllCars = cars,
				currCategory = currCategory
			};

			ViewBag.Title = "Основная страница";

			return View(carObj);
		}
	}
}
