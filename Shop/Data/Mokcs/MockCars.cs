using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mokcs
{
	public class MockCars : IAllCars
	{
		private readonly ICarsCategory _carsCategory = new MockCategory();
		public IEnumerable<Car> Cars
		{
			get
			{
				return new List<Car>
				{
					new Car {
						Name = "Tesla",
						ShortDesc = "Быстрый автомобиль",
						LongDesc = "Красивый, быстрый и очень тихий",
						Img = "/Img/Tesla.jpg",
						Price = 35000,
						IsFavourite = true,
						Availiable = true,
						Category = _carsCategory.AllCategories.First() 
					},
					new Car {
						Name = "Ford fiesta",
						ShortDesc = "Надежный автомобиль",
						LongDesc = "Старый, но надежны и очень тихий",
						Img = "/Img/1559021799_1.jpg",
						Price = 4500,
						IsFavourite = false,
						Availiable = true,
						Category = _carsCategory.AllCategories.Last()
					},
					new Car {
						Name = "Nissan Almera",
						ShortDesc = "Синий автомобиль",
						LongDesc = "Красивый, быстрый и очень тихий",
						Img = "/Img/1559021804_2.jpg",
						Price = 45000,
						IsFavourite = true,
						Availiable = true,
						Category = _carsCategory.AllCategories.Last()
					},
					new Car {
						Name = "Nissan GTR",
						ShortDesc = "Крутой автомобиль",
						LongDesc = "Красивый, быстрый и очень тихий",
						Img = "/Img/unnamed.jpg",
						Price = 10000,
						IsFavourite = true,
						Availiable = true,
						Category = _carsCategory.AllCategories.Last()
					}
				};
			}
		}

		public IEnumerable<Car> GetFavCars { get; set; }

		public Car GetObjectCar(int carId)
		{
			return Cars.FirstOrDefault();
		}
	}
}
