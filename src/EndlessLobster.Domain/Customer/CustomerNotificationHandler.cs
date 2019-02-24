using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using EndlessLobster.Repository;
using EndlessLobster.Repository.Models;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerNotificationHandler : INotificationHandler<CustomerNotification>
	{
		public Task Handle(CustomerNotification notification, CancellationToken cancellationToken)
		{
			var repository = new CustomerRepository();
			repository.Save(new CustomerDto {Name = notification.Name});

			return Task.CompletedTask;
		}
	}
}