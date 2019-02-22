using System.Collections.Generic;
using System.Linq;
using EndlessLobster.Domain;
using EndlessLobster.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EndlessLobster.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LobstersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IOrderService _orderService;
		private readonly ICustomerHistoryRepository _historyRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRespoitory;
		private readonly IRelatedProductsRepository _relatedProductsRepository;
		private readonly ISupportService _supportService;
		private readonly ILog _logger;

		public LobstersController(ICustomerRepository customerRepository,
			IOrderService orderService,
			ICustomerHistoryRepository historyRepository,
			IOrderRepository orderRepository,
			IProductRepository productRespoitory,
			IRelatedProductsRepository relatedProductsRepository,
			ISupportService supportService,
			ILog logger)
		{
			_customerRepository = customerRepository;
			_orderService = orderService;
			_historyRepository = historyRepository;
			_orderRepository = orderRepository;
			_productRespoitory = productRespoitory;
			_relatedProductsRepository = relatedProductsRepository;
			_supportService = supportService;
			_logger = logger;
		}

		// GET api/lobsters
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return _customerRepository.GetCustomerLobsters().ToArray();
		}

		// GET api/lobsters/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return _customerRepository.GetCustomerLobster(id);
		}

		// POST api/lobsters
		[HttpPost]
		public void Post([FromBody] string value)
		{
			_customerRepository.SaveCustomerLobster("lobster 3");
		}

		[HttpGet("GetOrder/{id}")]
		public ActionResult<string> GetOrder(int id)
		{
			return _orderService.GetOrder(id);
		}

		[HttpPost("SaveOrder")]
		public void SaveOrder([FromBody] string value)
		{
			_orderService.SaveOrder("lobster 3");
		}
	}
}
