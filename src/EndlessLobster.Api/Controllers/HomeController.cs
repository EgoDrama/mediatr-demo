using System;
using System.Collections.Generic;
using EndlessLobster.Api.Models;
using EndlessLobster.Domain;
using EndlessLobster.Repository;
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
			throw new NotImplementedException();
		}

		[HttpGet("customers/{id}")]
		public ActionResult<CustomerViewModel> GetCustomer(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost("customers")]
		public void CreateCustomer([FromBody] CustomerViewModel value)
		{
			throw new NotImplementedException();
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
