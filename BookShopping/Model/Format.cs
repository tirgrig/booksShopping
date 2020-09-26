using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopping.Model
{
    public class Format
    {
        [Key]
        public int FormatId { get; set; }
        public string FormatName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}