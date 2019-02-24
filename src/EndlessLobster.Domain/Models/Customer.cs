using System.Collections.Generic;

namespace EndlessLobster.Domain.Models
{
	public class Customer
	{
		public Customer(string name, IEnumerable<Order> orders)
		{
			Id++;
			Name = name;
			Orders = orders;
		}

		public int Id { get; }
		public string Name { get; }
		public IEnumerable<Order> Orders { get; }
	}
}