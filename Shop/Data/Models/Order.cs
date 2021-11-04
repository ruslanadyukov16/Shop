using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class Order
	{
		public int Id { get; set; }

		[Display(Name = "Введите имя")]
		[MinLength(5)]
		[Required(ErrorMessage = "Длина поля не менее 5 символов")]
		public string Name { get; set; }

		[Display(Name = "Введите фамилию")]
		[MinLength(5)]
		[Required(ErrorMessage = "Длина поля не менее 5 символов")]
		public string SurName { get; set; }

		[Display(Name = "Введите адрес")]
		[MinLength(5)]
		[Required(ErrorMessage = "Длина поля не менее 5 символов")]
		public string Address { get; set; }

		[Display(Name = "Введите телефон")]
		[MinLength(5)]
		[Required(ErrorMessage = "Длина поля не менее 5 символов")]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

		[Display(Name = "Введите Email")]
		[DataType(DataType.EmailAddress)]
		[MinLength(5)]
		[Required(ErrorMessage = "Длина поля не менее 5 символов")]
		public string Email { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderTime { get; set; }

		public IEnumerable<OrderDetail> OrderDetails { get; set; }
	}
}
