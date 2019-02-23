using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public interface IOrderRepository
	{
		IEnumerable<OrderDto> Get();
		OrderDto Get(int id);
		void Save(OrderDto order);
	}
}