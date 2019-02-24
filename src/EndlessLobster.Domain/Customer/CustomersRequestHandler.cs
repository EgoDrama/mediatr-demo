using System.Collections.Generic;
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
			var customers = _customerRepository.Get();

			return Task.FromResult(new List<Models.Customer>());
		}
	}
}