using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class CategoriesController : Controller
	{
		private AppDbContext _categories;

		public CategoriesController(AppDbContext categories)
		{
			_categories = categories;
		}

		public IEnumerable<Category> Get ()
		{
			return _categories.Categories;
		}
	}

		
}
