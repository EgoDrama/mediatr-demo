using System.Collections.Generic;

namespace EndlessLobster.Domain.Models
{
	public class Order
	{
		private readonly int _id = 1;

		public Order(string name, IEnumerable<Product> products)
		{
			Id = _id++;
			Name = name;
			Products = products;
		}

		public int Id { get; }
		public string Name { get; }
		public IEnumerable<Product> Products { get; }
	}
}