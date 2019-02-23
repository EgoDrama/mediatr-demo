using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public interface IProductRepository
	{
		IEnumerable<ProductDto> Get();
		ProductDto Get(int id);
		void Save(ProductDto product);
	}
}