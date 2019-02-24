using System.Collections.Generic;
using MediatR;

namespace EndlessLobster.Domain.Customer.Commands
{
	public class CustomersRequest : IRequest<List<Models.Customer>>
	{
	}
}