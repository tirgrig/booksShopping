
using System.ComponentModel.DataAnnotations;

namespace BookShopping.Model
{
    public class Book
    {
        [Key] public int BookId { get; set; }

        public string Author { get; set; }

        public string Titel { get; set; }

        public string Ean { get; set; }

        public string Publisher { get; set; }

        public string Data { get; set; }
        
        public string Prise { get; set; }
        
        public string Category { get; set; }
        
        public string Format { get; set; }
        /*public ArrayList FormatBooks { get; set; } = new ArrayList();*/
    }
}