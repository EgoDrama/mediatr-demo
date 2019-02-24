using System.Linq;
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
			var customerDto = _customerRepository.Get(request.Id);

			var customer = new Models.Customer(customerDto.Name, customerDto.Orders.Select(o => new Order(o.Name, o.Products.Select(p => new Product(p.Name)))));

			return Task.FromResult(customer);
		}
	}
}