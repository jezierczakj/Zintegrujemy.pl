using Zintegrujemyfin.Models;

namespace Zintegrujemyfin.Services.Interfaces
{
	/// <summary>
	/// Product Service
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Download files from web
		/// </summary>
		/// <returns></returns>
		public Result DownloadFIles();

		/// <summary>
		/// Read Products from file and save in database
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		Result SaveProducts(out IEnumerable<Product> products);

		/// <summary>
		/// Read Inventories from file and save in database
		/// </summary>
		/// <returns></returns>
		Result SaveInventories();

		/// <summary>
		/// Read Prices from file and save in database
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		Result SavePrices(IEnumerable<Product> products);

		/// <summary>
		/// Get product info by SKU
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		ProductData GetProduct(string sku);
	}
}
