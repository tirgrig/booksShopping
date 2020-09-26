using BookShopping.Model;
using Microsoft.EntityFrameworkCore;

namespace BookShopping.Repository
{
    public class PersonsEntitys : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
       protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=/home/tiran/RiderProjects/BookShopping/BookShopping/Source/sql.db");
    }
}