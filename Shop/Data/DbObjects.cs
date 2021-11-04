using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
	public static class DbObjects
	{
		public static void Initial(AppDbContext context)
		{
		

			if (!context.Categories.Any())
				context.Categories.AddRange(Categories.Select(c => c.Value));

			if (!context.Cars.Any())
			{
				context.AddRange(
					new List<Car>
				{
						new Car {
							Name = "Tesla",
							ShortDesc = "Быстрый автомобиль",
							LongDesc = "Красивый, быстрый и очень тихий",
							Img = "/Img/Tesla.jpg",
							Price = 35000,
							IsFavourite = true,
							Availiable = true,
							Category = Categories["Электромобили"]
						},
						new Car {
							Name = "Ford fiesta",
							ShortDesc = "Надежный автомобиль",
							LongDesc = "Старый, но надежны и очень тихий",
							Img = "/Img/1559021799_1.jpg",
							Price = 4500,
							IsFavourite = false,
							Availiable = true,
							Category = Categories["Классические автомобили"]
						},
						new Car {
							Name = "Nissan Almera",
							ShortDesc = "Синий автомобиль",
							LongDesc = "Красивый, быстрый и очень тихий",
							Img = "/Img/1559021804_2.jpg",
							Price = 45000,
							IsFavourite = true,
							Availiable = true,
							Category = Categories["Классические автомобили"]
						},
						new Car {
							Name = "Nissan GTR",
							ShortDesc = "Крутой автомобиль",
							LongDesc = "Красивый, быстрый и очень тихий",
							Img = "/Img/unnamed.jpg",
							Price = 10000,
							IsFavourite = true,
							Availiable = true,
							Category = Categories["Электромобили"],
						}
				});
			}
			context.SaveChanges();
		}

		private static Dictionary<string, Category> _category;

		public static Dictionary<string, Category> Categories
		{
			get
			{
				if (_category == null)
				{
					var list = new Category[]
					{
						new Category {CategoryName = "Электромобили", Description = "Современный"},
						new Category {CategoryName = "Классические автомобили", Description = "Классика"}
					};
				_category = new Dictionary<string, Category>();

					foreach (Category el in list)
						_category.Add(el.CategoryName, el);
				}

				return _category;
			}
		}
	}
}
