namespace EndlessLobster.Domain
{
	public interface IOrderService
	{
		string GetOrder(int id);
		void SaveOrder(string order);
	}
}