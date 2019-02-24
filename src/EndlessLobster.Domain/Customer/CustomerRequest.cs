using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerRequest: IRequest<Models.Customer>
	{
		public CustomerRequest(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}