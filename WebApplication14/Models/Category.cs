using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public string CreatedAt { get; set; }

        //a.CategoryId b.CategoryName c.Description d. Image e. Status f. Position g. CreatedAt
        public Category(int categoryid, string categoryname, string description, string image, string status,string position,string createdAt)
        {
     

            CategoryId = categoryid; 
            CategoryName = categoryname;
            Description = description; 
            Image = image; 
            Status = status;
            Position = position;
            CreatedAt = createdAt;


        }

        
    }
    
}