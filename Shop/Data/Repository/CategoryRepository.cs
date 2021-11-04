using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
	public class CategoryRepository : ICarsCategory
	{
		private readonly AppDbContext _appDbContent;

		public CategoryRepository(AppDbContext appDbContext)
		{
			_appDbContent = appDbContext;
		}

		public IEnumerable<Category> AllCategories => _appDbContent.Categories;
	}
}
