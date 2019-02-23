using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public interface ICustomerRepository
	{
		IEnumerable<CustomerDto> Get();
		CustomerDto Get(int id);
		void Save(CustomerDto customer);
	}
}