using System.Collections.Generic;
using EndlessLobster.Domain.Models;

namespace EndlessLobster.Domain
{
	public interface ICustomerService
	{
		IEnumerable<Customer> Get();
		Customer Get(int id);
		void Save(Customer customer);
	}
}