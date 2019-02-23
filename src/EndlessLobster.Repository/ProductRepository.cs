using System.Collections.Generic;
using EndlessLobster.Repository.Models;

namespace EndlessLobster.Repository
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<ProductDto> Get()
		{
			throw new System.NotImplementedException();
		}

		public ProductDto Get(int id)
		{
			throw new System.NotImplementedException();
		}

		public void Save(ProductDto product)
		{
			throw new System.NotImplementedException();
		}
	}
}