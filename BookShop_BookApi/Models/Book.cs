using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop_BookApi.Models
{
    public class Book
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        public string description { get; set; }
        public string coverUrl { get; set; }
        public decimal price { get; set; }
        public int stock {  get; set; }
        [Required]
        public DateTime addDate { get; set; }
        public string language {  get; set; }
        public string genre { get; set; }

    }
}
