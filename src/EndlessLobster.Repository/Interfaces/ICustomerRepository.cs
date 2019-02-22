using System.Collections.Generic;

namespace EndlessLobster.Repository
{
	public interface ICustomerRepository
	{
		IEnumerable<string> GetCustomerLobsters();
		string GetCustomerLobster(string id);
		void SaveCustomerLobster(string lobster);
	}
}