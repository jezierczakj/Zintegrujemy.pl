using Dapper;
using Microsoft.Data.Sqlite;
using Zintegrujemyfin.Models;
using Zintegrujemyfin.Repositories.Interfaces;

namespace Zintegrujemyfin.Repositories
{
	/// <summary>
	/// Product Repository
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		/// <summary>
		/// Create Products table if not exist and insert values
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		public Result SaveProducts(IEnumerable<Product> products)
		{
			var result = new Result();

			var createProductsTableQuery = "CREATE TABLE IF NOT EXISTS Products (ID CHAR, SKU CHAR PRIMARY KEY, name TEXT, EAN CHAR, producer_name TEXT, category TEXT, is_wire CHAR, available CHAR, is_vendor CHAR, default_image TEXT)";
			var deleteProductsQuery = "DELETE FROM Products";
			var insertProductsQuery = "INSERT INTO Products (ID, SKU, name, EAN, producer_name, category, is_wire, available, is_vendor, default_image) VALUES (@ID, @SKU, @name, @EAN, @producer_name, @category, @is_wire, @available, @is_vendor, @default_image)";

			try
			{
				using (var connection = new SqliteConnection($"Data Source=Database.db"))
				{
					connection.Query<Product>(createProductsTableQuery);
					connection.Query<Product>(deleteProductsQuery);
					connection.Execute(insertProductsQuery, products);
				}
			}
			catch (Exception e)
			{
				result.Errors.Add(e.Message);
			}

			return result;
		}

		/// <summary>
		/// Create Inventory table if not exist and insert values
		/// </summary>
		/// <param name="inventory"></param>
		/// <returns></returns>
		public Result SaveInventories(IEnumerable<Inventory> inventory)
		{
			var result = new Result();

			var createInventoryTableQuery = "CREATE TABLE IF NOT EXISTS Inventory (sku CHAR PRIMARY KEY, qty CHAR, unit CHAR, shipping_cost CHAR)";
			var deleteInventoryTableQuery = "DELETE FROM Inventory";
			var insertInventoryTableQuery = "INSERT INTO Inventory (sku, unit, qty, shipping_cost) VALUES (@sku, @unit,  @qty, @shipping_cost)";

			try
			{
				using (var connection = new SqliteConnection($"Data Source=Database.db"))
				{
					connection.Query<Inventory>(createInventoryTableQuery);
					connection.Query<Inventory>(deleteInventoryTableQuery);
					connection.Execute(insertInventoryTableQuery, inventory);
				}
			}
			catch (Exception e)
			{
				result.Errors.Add(e.Message);
			}

			return result;
		}

		/// <summary>
		/// Create Prices table if not exist and insert values
		/// </summary>
		/// <param name="prices"></param>
		/// <returns></returns>
		public Result SavePrices(IEnumerable<Prices> prices)
		{
			var result = new Result();

			var createPricesTableQuery = "CREATE TABLE IF NOT EXISTS Prices (SKU CHAR PRIMARY KEY, nett_price CHAR)";
			var deletePricesTableQuery = "DELETE FROM Prices";
			var insertPricesTableQuery = "INSERT INTO Prices (SKU, nett_price) VALUES (@SKU, @nett_price)";

			try
			{
				using (var connection = new SqliteConnection($"Data Source=Database.db"))
				{
					connection.Query<Prices>(createPricesTableQuery);
					connection.Query<Prices>(deletePricesTableQuery);
					connection.Execute(insertPricesTableQuery, prices);
				}
			}
			catch (Exception e)
			{
				result.Errors.Add(e.Message);
			}

			return result;
		}

		/// <summary>
		/// Get product info by SKU
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		public ProductData GetProduct(string sku)
		{
			var productData = new ProductData();

			var selectProductDataBySkuQuery = "SELECT Products.name, Products.EAN, Products.producer_name, Products.category, Products.default_image, Inventory.qty, Inventory.unit, Prices.nett_price, Inventory.shipping_cost " +
				"FROM Products LEFT JOIN Inventory ON Inventory.sku = Products.sku LEFT JOIN Prices ON Prices.sku = Products.sku WHERE Products.SKU = '{0}'";
			var query = string.Format(selectProductDataBySkuQuery, sku);

			try
			{
				using (var connection = new SqliteConnection($"Data Source=Database.db"))
				{
					productData = connection.Query<ProductData>(query)?.FirstOrDefault();
				}
			}
			catch
			{
				return null;
			}

			return productData;
		}
	}
}
