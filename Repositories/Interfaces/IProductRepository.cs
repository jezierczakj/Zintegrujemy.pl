using Zintegrujemyfin.Models;

namespace Zintegrujemyfin.Repositories.Interfaces
{
	/// <summary>
	/// Product Repository
	/// </summary>
	public interface IProductRepository
	{
		/// <summary>
		/// Create Products table if not exist and insert values
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		Result SaveProducts(IEnumerable<Product> products);

		/// <summary>
		/// Create Inventory table if not exist and insert values
		/// </summary>
		/// <param name="inventory"></param>
		/// <returns></returns>
		Result SaveInventories(IEnumerable<Inventory> inventory);

		/// <summary>
		/// Create Prices table if not exist and insert values
		/// </summary>
		/// <param name="prices"></param>
		/// <returns></returns>
		Result SavePrices(IEnumerable<Prices> prices);

		/// <summary>
		/// Get product info by SKU
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		ProductData GetProduct(string sku);
	}
}
