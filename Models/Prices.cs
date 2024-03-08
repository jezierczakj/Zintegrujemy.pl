using CsvHelper.Configuration.Attributes;

namespace Zintegrujemyfin.Models
{
    /// <summary>
    /// Prices
    /// </summary>
    public class Prices
    {
        /// <summary>
        /// Id
        /// </summary>
        [Index(0)]
        public string ID { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        [Index(1)]
        public string SKU { get; set; }
        /// <summary>
        /// Nett Price
        /// </summary>
        [Index(2)]
        public string nett_price { get; set; }
        /// <summary>
        /// Nett Price after discount
        /// </summary>
        [Index(3)]
        public string nett_price_after_disscount { get; set; }
        /// <summary>
        /// VAT
        /// </summary>
        [Index(4)]
        public string VAT { get; set; }
        /// <summary>
        /// Nett Cost for shipping
        /// </summary>
        [Index(5)]
        public string nett_cost_for_shipping { get; set; }
    }
}
