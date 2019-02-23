using System.Collections.Generic;
using EndlessLobster.Domain.Models;

namespace EndlessLobster.Domain
{
	public interface IOrderService
	{
		IEnumerable<Order> Get();
		Order Get(int id);
		void Save(Order order);
	}
}