using Microsoft.AspNetCore.Mvc;
using Zintegrujemyfin.Services;

namespace Zintegrujemyfin.Controllers
{
	/// <summary>
	/// Products Controller
	/// </summary>
	[Route("[controller]")]
	public class ProductsController : Controller
	{
		private readonly ProductService _service;
		public ProductsController() 
		{
			_service = new ProductService();
		}

		/// <summary>
		/// Read files from web and save in database
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("SaveProducts", Name = "SaveProducts")]
		public IActionResult SaveProducts()
		{
			var result = _service.DownloadFIles();
			if (result.IsValid)
			{
				result += _service.SaveProducts(out var products);
				result += _service.SaveInventories();
				result += _service.SavePrices(products);

				if (result.IsValid)
				{
					return Ok("Success");
				}
			}

			return StatusCode(500, result.Errors);
		}

		/// <summary>
		/// Get product info by SKU
		/// </summary>
		/// <param name="sku"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("GetProduct", Name = "GetProduct")]
		public IActionResult GetProduct(string sku) 
		{
			if (string.IsNullOrWhiteSpace(sku))
			{
				return BadRequest("Please enter value");
			}

			var product = _service.GetProduct(sku);

			if (product == null)
			{
				return NotFound($"No records for SKU: {sku}");
			}

			return Ok(product);
		}
	}
}
