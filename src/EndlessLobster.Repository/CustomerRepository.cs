using System;
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

		public string GetCustomerLobster(int id)
		{
			var search = $"lobster {id}";
			var lobster = _customerLobsters.FirstOrDefault(x => x == search);

			if (lobster == null) throw new Exception($"Id {id} does not exist.");

			return lobster;
		}

		public void SaveCustomerLobster(string lobster)
		{
			_customerLobsters.Add(lobster);
		}
	}
}