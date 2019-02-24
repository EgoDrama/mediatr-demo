﻿using System.Collections.Generic;
using System.Linq;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly IList<CustomerDto> _customers;

		public CustomerRepository()
		{
			_customers = new List<CustomerDto>
			{
				new CustomerDto {Id=1, Name = "Customer 1", Orders = new List<OrderDto>
				{
					new OrderDto
					{
						Id = 1,
						Name = "Order 1",
						Products = new List<ProductDto>
						{
							new ProductDto
							{
								Id = 1,
								Name = "product 1"
							}
						}}}},
				new CustomerDto {Id=2, Name = "Customer 2", Orders = new List<OrderDto>
				{
					new OrderDto
					{
						Id = 2,
						Name = "Order 2",
						Products = new List<ProductDto>
						{
							new ProductDto
							{
								Id = 2,
								Name = "product 2"
							}
						}}}}
			};
		}

		public IEnumerable<CustomerDto> Get()
		{
			return _customers;
		}

		public CustomerDto Get(int id)
		{
			return _customers.FirstOrDefault(x => x.Id == id);
		}

		public void Save(CustomerDto customer)
		{
			_customers.Add(customer);
		}
	}
}