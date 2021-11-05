using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
	public class Car
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		public string Img { get; set; }
		public ushort Price { get; set; }
		public bool IsFavourite { get; set; }
		public bool Availiable { get; set; }
		public byte[] Data { get; set; }
		public string DataBase64 { get => Convert.ToBase64String(Data);}
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
