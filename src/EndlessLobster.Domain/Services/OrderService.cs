namespace EndlessLobster.Domain.Services
{
	public class OrderService : IOrderService
	{
		public string GetOrder(int id)
		{
			return $"my order with id {id}";
		}

		public void SaveOrder(string order)
		{
			// save
		}
	}
}