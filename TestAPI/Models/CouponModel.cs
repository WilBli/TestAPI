namespace TestAPI.Models
{
    public class CouponModel
    {
        public int ID { get; set; }
        public string CouponCode { get; set; } // Promo coupon / Voucher 
        public DateTime ExpiryDateUTC { get; set; }
        public double Amount { get; set; }

        public IList<CountryModel> ValidCountries { get; set; } // Countries where the coupon is valid
        public IList<ProductModel> ValidProducts { get; set; } // Products for which the coupon is valid
    }
}
