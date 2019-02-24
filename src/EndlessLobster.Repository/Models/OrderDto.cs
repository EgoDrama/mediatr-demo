using System.Collections.Generic;

namespace EndlessLobster.Repository.Models
{
	public class OrderDto
	{
		public OrderDto()
		{
			Products = new List<ProductDto>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<ProductDto> Products { get; set; }
	}
}