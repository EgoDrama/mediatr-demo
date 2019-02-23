using System.Collections.Generic;
using EndlessLobster.Domain.Models;

namespace EndlessLobster.Domain
{
	public interface IProductService
	{
		IEnumerable<Product> Get();
		Product Get(int id);
		void Save(Product product);
	}
}