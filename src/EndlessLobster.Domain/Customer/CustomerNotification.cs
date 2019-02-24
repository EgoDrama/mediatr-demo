using System.Collections.Generic;
using EndlessLobster.Domain.Models;
using MediatR;

namespace EndlessLobster.Domain.Customer
{
	public class CustomerNotification : INotification
	{
		public CustomerNotification(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
		public IEnumerable<Order> Orders { get; set; }
	}
}