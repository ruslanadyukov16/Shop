using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class OrderDetail
{
		private readonly AppDbContext _appDbContent;

		public OrderDetail(AppDbContext appDbContext)
		{
			_appDbContent = appDbContext;
		}

		public int Id { get; set; }

		public int OrderId { get; set; }

		public int CarId { get; set; }

		public uint Price { get; set; }

		public virtual Car Car
		{
			get
			{
				var orderDetail = _appDbContent.Cars.Where(c => c.Id == CarId);
				return orderDetail.FirstOrDefault();
			}
		}

		public virtual Order Order { get; set; }
	}
}
