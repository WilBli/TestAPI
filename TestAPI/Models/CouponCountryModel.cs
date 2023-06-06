namespace TestAPI.Models
{
    public class CouponCountryModel
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public Guid CountryId { get; set; }
    }
}
