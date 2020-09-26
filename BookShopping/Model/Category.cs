using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopping.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        private List<Format> Formats { get; set; } = new List<Format>();
    }
}