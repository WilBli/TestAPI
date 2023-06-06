namespace TestAPI.Models
{
    public class CouponProductModel
    {
        public int ID { get; set; }
        public string CouponCode { get; set; }
        public Guid ProductID { get; set; }
    }
}
