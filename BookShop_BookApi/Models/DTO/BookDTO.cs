using System.ComponentModel.DataAnnotations;

namespace BookShop_BookApi.Models.DTO
{
    public class BookDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string coverUrl { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string language { get; set; }
        public string genre { get; set; }
    }
}
