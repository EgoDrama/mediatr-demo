using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Domain.Models;
using EndlessLobster.Repository;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerRequestHandler : IRequestHandler<CustomerRequest, Models.Customer>
	{
		public Task<Models.Customer> Handle(CustomerRequest request, CancellationToken cancellationToken)
		{
			var repository = new CustomerRepository();
			var customer = repository.Get(request.Id);

			return Task.FromResult(new Models.Customer(customer.Name, new List<Order>()));
		}
	}
}