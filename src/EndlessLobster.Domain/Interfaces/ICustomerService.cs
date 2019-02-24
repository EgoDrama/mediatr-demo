using System.Collections.Generic;

namespace EndlessLobster.Domain
{
	public interface ICustomerService
	{
		IEnumerable<Models.Customer> Get();
		Models.Customer Get(int id);
		void Save(Models.Customer customer);
	}
}