using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopping.Model
{
    public class Person
    {
        [Key]
        public int PersonUid { get; set; }
        public  string Gender { get; set; }
        public  string Lastname { get; set; }
        public  string Surname { get; set; }
        public  string StreetAddress { get; set; }
        public  string ZipCode { get; set; }
        public  string City { get; set; }
        public  string Email { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }
        public  DateTime Birthday { get; set; }
    }
}