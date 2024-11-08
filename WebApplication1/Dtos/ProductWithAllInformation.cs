namespace WebApplication1.Dtos
{
    public class ProductWithAllInformation
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public string BrandName { get; set; }
        public List<string> ProductImageUrl { get; set; } = new List<string>() { };

    }
}
