using System.Collections.Generic;

namespace EndlessLobster.Api.Models
{
	public class OrderViewModel
	{
		public OrderViewModel()
		{
			Products = new List<ProductViewModel>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<ProductViewModel> Products { get; set; }
	}
}