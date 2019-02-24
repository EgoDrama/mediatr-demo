namespace EndlessLobster.Domain.Models
{
	public class Product
	{
		private readonly int _id = 1;

		public Product(string name)
		{
			Id = _id++;
			Name = name;
		}

		public int Id { get; }
		public string Name { get; }
	}
}