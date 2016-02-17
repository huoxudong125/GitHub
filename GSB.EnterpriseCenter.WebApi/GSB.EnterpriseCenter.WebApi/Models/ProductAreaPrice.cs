namespace GSB.EnterpriseCenter.WebApi.Models
{
    public class ProductAreaPrice
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string AreaId { get; set; }

        public int Price { get; set; }

        public virtual Product Product { get; set; }
        public CityArea CityArea { get; set; }
    }
}