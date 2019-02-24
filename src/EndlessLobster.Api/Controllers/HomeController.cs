using System;
using System.Collections.Generic;
using System.Linq;
using EndlessLobster.Api.Models;
using EndlessLobster.Domain;
using EndlessLobster.Domain.Models;
using EndlessLobster.Repository;
using EndlessLobster.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndlessLobster.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IProductRepository _productRespoitory;
		private readonly IOrderRepository _orderRepository;

		private readonly ICustomerService _customerService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;

		private readonly ILog _logger;

		public HomeController(
			ICustomerRepository customerRepository,
			IProductRepository productRespoitory,
			IOrderRepository orderRepository,
			ICustomerService customerService,
			IProductService productService,
			IOrderService orderService,
			ILog logger)
		{
			_customerRepository = customerRepository;
			_productRespoitory = productRespoitory;
			_orderRepository = orderRepository;
			_customerService = customerService;
			_productService = productService;
			_orderService = orderService;
			_logger = logger;
		}

		[HttpGet("customers")]
		public ActionResult<IEnumerable<CustomerViewModel>> GetCustomers()
		{
			var customers = _customerRepository.Get();

			return MapCustomers(customers);
		}

		private static CustomerViewModel[] MapCustomers(IEnumerable<CustomerDto> customers)
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
				})}).ToArray();
		}

		[HttpGet("customers/{id}")]
		public ActionResult<CustomerViewModel> GetCustomer(int id)
		{
			var customer = _customerRepository.Get(id);

			return MapCustomer(customer);
		}

		private static CustomerViewModel MapCustomer(CustomerDto customer)
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
				})};
		}

		[HttpPost("customers")]
		public void CreateCustomer([FromBody] CustomerViewModel value)
		{
			IList<Order> orders = new List<Order>();
			IList<Product> products = new List<Product>();

			foreach (var order in value.Orders)
			{
				foreach (var product in order.Products)
				{
					products.Add(new Product(product.Name));
				}
				orders.Add(new Order(order.Name, products));
			}

			var customer = new Customer(value.Name, orders);

			_customerService.Save(customer);
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
