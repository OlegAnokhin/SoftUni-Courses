namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportProductDTO
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }
    }
}
