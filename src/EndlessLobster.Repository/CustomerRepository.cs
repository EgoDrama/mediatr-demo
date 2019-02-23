using System;
using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		public IEnumerable<CustomerDto> Get()
		{
			throw new NotImplementedException();
		}

		public CustomerDto Get(int id)
		{
			throw new NotImplementedException();
		}

		public void Save(CustomerDto customer)
		{
			throw new NotImplementedException();
		}
	}
}