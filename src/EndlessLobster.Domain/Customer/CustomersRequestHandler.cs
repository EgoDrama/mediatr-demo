using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Domain.Customer.Commands;
using EndlessLobster.Repository;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomersRequestHandler : IRequestHandler<CustomersRequest, List<Models.Customer>>
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomersRequestHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public Task<List<Models.Customer>> Handle(CustomersRequest request, CancellationToken cancellationToken)
		{
			var customersDto = _customerRepository.Get();

			var customers = customersDto.Select(c => new Models.Customer(c.Name,
				c.Orders.Select(o => new Models.Order(o.Name, o.Products.Select(p => new Models.Product(p.Name)))))).ToList();

			return Task.FromResult(customers);
		}
	}
}