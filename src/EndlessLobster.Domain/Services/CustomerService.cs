using System.Collections.Generic;
using EndlessLobster.Repository;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Domain.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public IEnumerable<Models.Customer> Get()
		{
			throw new System.NotImplementedException();
		}

		public Models.Customer Get(int id)
		{
			throw new System.NotImplementedException();
		}

		public void Save(Models.Customer customer)
		{
			var ordersDto = new List<OrderDto>();
			var productsDto = new List<ProductDto>();

			foreach (var order in customer.Orders)
			{
				foreach (var product in order.Products)
				{
					productsDto.Add(new ProductDto{Id = product.Id, Name = product.Name});
				}
				ordersDto.Add(new OrderDto {Id = order.Id, Name = order.Name, Products = productsDto});
			}

			var customerDto = new CustomerDto {Id = customer.Id, Name = customer.Name, Orders = new List<OrderDto>()};
			_customerRepository.Save(customerDto);
		}
	}
}