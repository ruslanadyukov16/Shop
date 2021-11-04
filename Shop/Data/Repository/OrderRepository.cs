using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
	public class OrderRepository : IAllOrders
	{
		private readonly AppDbContext _appDbContext;
		private readonly ShopCart _shopCart;

		public OrderRepository(AppDbContext appDbContext, ShopCart shopCart)
		{
			_appDbContext = appDbContext;
			_shopCart = shopCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderTime = DateTime.Now;
			_appDbContext.Order.Add(order);
			_appDbContext.SaveChanges();

			var items = _shopCart.ShopCarItems;

			foreach(var item in items)
			{
				var orderDetail = new OrderDetail(_appDbContext)
				{
					CarId = item.Car.Id,
					OrderId = order.Id,
					Price = item.Car.Price
				};

				_appDbContext.OrderDetail.Add(orderDetail);
			}

			_appDbContext.SaveChanges();
		}
		public IEnumerable<Order> GetOrders() => _appDbContext.Order.Include(order => order.OrderDetails);
	}
}
