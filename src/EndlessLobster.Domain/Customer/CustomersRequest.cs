using System.Collections.Generic;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomersRequest : IRequest<List<Models.Customer>>
	{
	}
}