using System.Collections.Generic;

namespace EndlessLobster.Api.Models
{
	public class CustomerViewModel
	{
		public CustomerViewModel()
		{
			Orders = new List<OrderViewModel>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<OrderViewModel> Orders { get; set; }
	}
}