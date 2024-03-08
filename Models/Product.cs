namespace Zintegrujemyfin.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Reference Number
        /// </summary>
        public string reference_number { get; set; }
        /// <summary>
        /// EAN
        /// </summary>
        public string EAN { get; set; }
        /// <summary>
        /// Can be returned
        /// </summary>
        public string can_be_returned { get; set; }
        /// <summary>
        /// Producer Name
        /// </summary>
        public string producer_name { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// Is Wire
        /// </summary>
        public string is_wire { get; set; }
        /// <summary>
        /// Shipping
        /// </summary>
        public string shipping { get; set; }
        /// <summary>
        /// Package Size
        /// </summary>
        public string package_size { get; set; }
        /// <summary>
        /// Available
        /// </summary>
        public string available { get; set; }
        /// <summary>
        /// Logistic Height
        /// </summary>
        public string logistic_height { get; set; }
        /// <summary>
        /// Logistic Width
        /// </summary>
        public string logistic_width { get; set; }
		/// <summary>
		/// Logistic Length
		/// </summary>
		public string logistic_length { get; set; }
		/// <summary>
		/// Logistic Weight
		/// </summary>
		public string logistic_weight { get; set; }
        /// <summary>
        /// Is Vendor
        /// </summary>
        public string is_vendor { get; set; }
        /// <summary>
        /// Available in parcel locker
        /// </summary>
        public string available_in_parcel_locker { get; set; }
        /// <summary>
        /// Default Image URL
        /// </summary>
        public string default_image { get; set; }
    }
}
