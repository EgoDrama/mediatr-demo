using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public class OrderRepository : IOrderRepository
	{
		public IEnumerable<OrderDto> Get()
		{
			throw new System.NotImplementedException();
		}

		public OrderDto Get(int id)
		{
			throw new System.NotImplementedException();
		}

		public void Save(OrderDto order)
		{
			throw new System.NotImplementedException();
		}
	}
}