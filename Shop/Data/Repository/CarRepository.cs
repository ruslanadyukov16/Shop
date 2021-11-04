using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
	public class CarRepository : IAllCars
	{
		private readonly AppDbContext _appDbContent;

		public CarRepository(AppDbContext appDbContext)
		{
			_appDbContent = appDbContext;
		}

		public IEnumerable<Car> Cars => _appDbContent.Cars.Include(c => c.Category);

		public IEnumerable<Car> GetFavCars => _appDbContent.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

		public Car GetObjectCar(int carId) => _appDbContent.Cars.FirstOrDefault(car => car.Id == carId);
	}
}
