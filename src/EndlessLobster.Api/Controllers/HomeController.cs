using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndlessLobster.Api.Models;
using EndlessLobster.Domain;
using EndlessLobster.Domain.Customer;
using EndlessLobster.Domain.Customer.Commands;
using EndlessLobster.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndlessLobster.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILog _logger;

		public HomeController(
			IMediator mediator,
			ILog logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet("customers")]
		public async Task<ActionResult<List<CustomerViewModel>>> GetCustomers()
		{
			var response = await _mediator.Send(new CustomersRequest());

			return MapCustomers(response);
		}

		[HttpGet("customers/{id}")]
		public async Task<ActionResult<CustomerViewModel>> GetCustomer(int id)
		{

			var response = await _mediator.Send(new CustomerRequest(id));

			return MapCustomer(response);
		}

		[HttpPost("customers")]
		public async Task CreateCustomer([FromBody] CustomerViewModel value)
		{
			await _mediator.Publish(new CustomerNotification(value.Name));
		}

		private static List<CustomerViewModel> MapCustomers(IEnumerable<Customer> customers)
		{
			return customers.Select(c => new CustomerViewModel
			{
				Id = c.Id,
				Name = c.Name,
				Orders = c.Orders.Select(o => new OrderViewModel
				{
					Id = o.Id,
					Name = o.Name,
					Products = o.Products.Select(p => new ProductViewModel
					{
						Id = p.Id,
						Name = p.Name
					})
				})
			}).ToList();
		}

		private static CustomerViewModel MapCustomer(Customer customer)
		{
			return new CustomerViewModel
			{
				Id = customer.Id,
				Name = customer.Name,
				Orders = customer.Orders.Select(o => new OrderViewModel
				{
					Id = o.Id,
					Name = o.Name,
					Products = o.Products.Select(p => new ProductViewModel
					{
						Id = p.Id,
						Name = p.Name
					})
				})
			};
		}

		[HttpGet("products")]
		public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
		{
			throw new NotImplementedException();
		}

		[HttpGet("products/{id}")]
		public ActionResult<CustomerViewModel> GetProduct(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost("products")]
		public void CreateProduct([FromBody] ProductViewModel value)
		{
			throw new NotImplementedException();
		}

		[HttpGet("orders")]
		public ActionResult<IEnumerable<OrderViewModel>> GetOrders()
		{
			throw new NotImplementedException();
		}

		[HttpGet("orders/{id}")]
		public ActionResult<OrderViewModel> GetOrder(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost("orders")]
		public void CreateOrder([FromBody] OrderViewModel value)
		{
			throw new NotImplementedException();
		}
	}
}
