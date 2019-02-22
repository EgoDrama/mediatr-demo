using System.Collections.Generic;
using System.Linq;

namespace EndlessLobster.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly IList<string> _customerLobsters = new List<string> { "lobster 1", "lobster 2" };

		public IEnumerable<string> GetCustomerLobsters()
		{
			return _customerLobsters;
		}

		public string GetCustomerLobster(string id)
		{
			return _customerLobsters.FirstOrDefault(x => x == id);
		}

		public void SaveCustomerLobster(string lobster)
		{
			_customerLobsters.Add(lobster);
		}
	}
}