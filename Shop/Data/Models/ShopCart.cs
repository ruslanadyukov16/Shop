using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class ShopCart
	{
		private readonly AppDbContext _appDbContent;

		public ShopCart(AppDbContext appDbContext)
		{
			_appDbContent = appDbContext;
		}

		public string ShopCartId { get; set; } = "1";

		public List<ShopCarItem> ShopCarItems { get; set; }

		public static ShopCart GetCart(IServiceProvider service)
		{
			ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			var context = service.GetService<AppDbContext>();
			string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCarId);

			return new ShopCart(context) { ShopCartId = shopCarId };
		}

		public void AddToCar (Car car)
		{
			_appDbContent.ShopCarItems.Add(new ShopCarItem
			{
				ShopCartId = ShopCartId,
				Car = car,
				Price = car.Price
			});

			_appDbContent.SaveChanges();
		}

		public List<ShopCarItem> GetShopCarItems()
		{
			return _appDbContent.ShopCarItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Car).ToList();
		}
	}
}
