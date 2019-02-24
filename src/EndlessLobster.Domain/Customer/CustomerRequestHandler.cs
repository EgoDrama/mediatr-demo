using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Domain.Customer.Commands;
using EndlessLobster.Domain.Models;
using EndlessLobster.Repository;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerRequestHandler : IRequestHandler<CustomerRequest, Models.Customer>
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerRequestHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public Task<Models.Customer> Handle(CustomerRequest request, CancellationToken cancellationToken)
		{
			var customer = _customerRepository.Get(request.Id);

			return Task.FromResult(new Models.Customer(customer.Name, new List<Order>()));
		}
	}
}