using System;
namespace TrussApi.Models
{
	public class ProductModel
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Code { get; set; }
		public required decimal price { get; set; }
		public string? linha {get; set;}
		public string? subLinha { get; set; }
	}
}

