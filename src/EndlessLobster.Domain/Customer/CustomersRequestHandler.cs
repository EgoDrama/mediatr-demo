using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Repository;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomersRequestHandler : IRequestHandler<CustomersRequest, List<Models.Customer>>
	{
		public Task<List<Models.Customer>> Handle(CustomersRequest request, CancellationToken cancellationToken)
		{
			var repository = new CustomerRepository();
			var customers = repository.Get();

			return Task.FromResult(new List<Models.Customer>());
		}
	}
}