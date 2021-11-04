using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
		}

	

		//private string _connection;
		//public AppDbContext ()
		//{
		//	_connection = "Server=(localdb)\\LocalServer;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
		//}

		public DbSet<Car> Cars { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShopCarItem> ShopCarItems { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderDetail> OrderDetail { get; set; }

	}
}
