using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId{ get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book(int bookid, int categoryid, string title, string isbn, int year, int price, string description, string position, string status,string image)
        {
            BookId = bookid;
            CategoryId = categoryid;
            Title = title;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = status;
            Image = image;

        }
    }
}


//BookId b.CategoryId c.Title d. ISBN e. Year f. Price g. Description h. Position i. Status j. Image