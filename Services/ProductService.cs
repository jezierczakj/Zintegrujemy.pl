using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Net;
using Zintegrujemyfin.Models;
using Zintegrujemyfin.Repositories;
using Zintegrujemyfin.Services.Interfaces;

namespace Zintegrujemyfin.Services
{
	/// <summary>
	/// Product Service
	/// </summary>
	public class ProductService : IProductService
	{
		private readonly ProductRepository _repository;
		
		public ProductService()
		{
			_repository = new ProductRepository();
		}
			
		/// <summary>
		/// Download files from web
		/// </summary>
		/// <returns></returns>
		public Result DownloadFIles()
		{
			var result = new Result();
			try
			{
				using (var client = new WebClient())
				{
					client.DownloadFile("https://rekturacjazadanie.blob.core.windows.net/zadanie/Products.csv", "Products.csv");
					client.DownloadFile("https://rekturacjazadanie.blob.core.windows.net/zadanie/Inventory.csv", "Inventory.csv");
					client.DownloadFile("https://rekturacjazadanie.blob.core.windows.net/zadanie/Prices.csv", "Prices.csv");
				};
			}
			catch (Exception ex) 
			{
				result.Errors.Add(ex.Message);
			}

			return result;
		}

		/// <summary>
		/// Read Products from file and save in database
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		public Result SaveProducts(out IEnumerable<Product> products)
		{
			products = Enumerable.Empty<Product>();
			using (var productReader = new StreamReader("Products.csv"))
			{
				var csvProductConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
				{
					Delimiter = ";",
					MissingFieldFound = null
				};

				using (var reader = new CsvReader(productReader, csvProductConfig))
				{
					var readRecords = reader.GetRecords<Product>();
					if (readRecords != null)
					{
						products = readRecords.Where(product => product.SKU != null && product.is_wire != "1" && product.shipping == "24h").ToList();
					}
				}
			}

			return _repository.SaveProducts(products);
		}

		/// <summary>
		/// Read Inventories from file and save in database
		/// </summary>
		/// <returns></returns>
		public Result SaveInventories()
		{
			var inventories = Enumerable.Empty<Inventory>();
			using (var inventoryReader = new StreamReader("Inventory.csv"))
			{
				var csvInventoryConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
				{
					MissingFieldFound = null
				};

				using (var reader = new CsvReader(inventoryReader, csvInventoryConfig))
				{
					var readRecords = reader.GetRecords<Inventory>();
					if (readRecords != null)
					{
						inventories = readRecords.Where(invent => invent.sku != null && invent.shipping == "24h").ToList();
					}
				}
			}

			return _repository.SaveInventories(inventories);
		}

		/// <summary>
		/// Read Prices from file and save in database
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		public Result SavePrices(IEnumerable<Product> products)
		{
			var prices = Enumerable.Empty<Prices>();
			var productSkus = products.Select(product => product.SKU);

			using (var pricesReader = new StreamReader("Prices.csv"))
			{
				var csvPricesConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
				{
					HasHeaderRecord = false,
					MissingFieldFound = null
				};

				using (var reader = new CsvReader(pricesReader, csvPricesConfig))
				{
					var readRecords = reader.GetRecords<Prices>();
					if (readRecords != null)
					{
						prices = readRecords.Where(price => price.SKU != null && productSkus.Contains(price.SKU)).ToList();
					}
				}
			}

			return _repository.SavePrices(prices);
		}

		/// <summary>
		/// Get product info by SKU
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public ProductData GetProduct(string sku) 
		{
			return _repository.GetProduct(sku);		
		}
	}
}
