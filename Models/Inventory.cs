namespace Zintegrujemyfin.Models
{
    /// <summary>
    /// Inventory
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public string sku { get; set; }
        /// <summary>
        /// Unit
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public string qty { get; set; }
        /// <summary>
        /// Manufacturer Name
        /// </summary>
        public string manufacturer_name { get; set; }
        /// <summary>
        /// Manufacturer Reference Number
        /// </summary>
        public string manufacturer_ref_num { get; set; }
        /// <summary>
        /// Shipping
        /// </summary>
        public string shipping { get; set; }
        /// <summary>
        /// Shipping Cost
        /// </summary>
        public string shipping_cost { get; set; }
    }
}
