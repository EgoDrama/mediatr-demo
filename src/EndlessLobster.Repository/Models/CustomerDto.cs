using System.Collections.Generic;

namespace EndlessLobster.Repository.Models
{
	public class CustomerDto
	{
		public CustomerDto()
		{
			Orders = new List<OrderDto>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<OrderDto> Orders { get; set; }
	}
}