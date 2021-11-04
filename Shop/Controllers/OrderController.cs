using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders _allOrders;
		private readonly ShopCart _shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			_allOrders = allOrders;
			_shopCart = shopCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			_shopCart.ShopCarItems = _shopCart.GetShopCarItems();

			if (_shopCart.ShopCarItems.Count == 0)
			{
				ModelState.AddModelError("", "У вас должны находиться товары в корзине");
			}

			if (ModelState.IsValid)
			{
				_allOrders.CreateOrder(order);

				return RedirectToAction("Complete");
			}

			return View(order);
		}

		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ успешно обработан";
			return View();
		}

		public IActionResult GetOrders()
		{
			var orders = new OrderListViewModel()
			{
				AllOrders = _allOrders.GetOrders()
			};
			
			
			return View(orders);
		}
	}
}
