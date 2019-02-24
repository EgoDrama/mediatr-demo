using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Domain.Customer.Commands;
using EndlessLobster.Repository;
using EndlessLobster.Repository.Models;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerNotificationHandler : INotificationHandler<CustomerNotification>
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerNotificationHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public Task Handle(CustomerNotification notification, CancellationToken cancellationToken)
		{
			_customerRepository.Save(new CustomerDto {Name = notification.Name});

			return Task.CompletedTask;
		}
	}
}