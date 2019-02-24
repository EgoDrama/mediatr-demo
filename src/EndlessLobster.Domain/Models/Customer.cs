using System.Collections.Generic;

namespace EndlessLobster.Domain.Models
{
	public class Customer
	{
		private readonly int _id = 1;

		public Customer(string name, IEnumerable<Order> orders)
		{
			Id = _id++;
			Name = name;
			Orders = orders;
		}

		public int Id { get; }
		public string Name { get; }
		public IEnumerable<Order> Orders { get; }
	}
}