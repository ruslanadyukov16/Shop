using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
	public class OrderListViewModel
	{
		public IEnumerable<Order> AllOrders { get; set; }
	}
}
