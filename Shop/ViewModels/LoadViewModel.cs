using Microsoft.AspNetCore.Http;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
	public class LoadViewModel
	{
		public Car Car { get; set; }
		public string CategoryName { get; set; }
		public IFormFile File { get; set; }
	}
}
