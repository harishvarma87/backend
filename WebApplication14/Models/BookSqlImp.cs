using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication14.Models
{
    public class BookSqlImp : IBookRepository
    {
        SqlCommand comm;
        SqlConnection conn;

        public BookSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book (CategoryId,Title,ISBN,[Year],Price,[Description],[Image],[Status],Position) values( " + book.CategoryId + ",'" + book.Title + "', '" + book.ISBN + "'," + book.Year + ", " + book.Price + ",'" + book.Description + "', '" + book.Image + "','" + book.Status + "', '" + book.Position + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void DeleteBook(int id)
        {
            comm.CommandText = "Delete from Book where BookId=" + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookid = Convert.ToInt32(reader["BookId"]);
                int categoryid = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                string position = reader["Position"].ToString();
                list.Add(new Book(bookid, categoryid, title, isbn, year, price, description, image, status, position));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(int id)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book where BookId="+id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookid = Convert.ToInt32(reader["BookId"]);
                int categoryid = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string position = reader["Position"].ToString();
                string status = reader["Status"].ToString();
                Book book = new Book(bookid, categoryid, title, isbn, year, price, description, position, status, image);
                return book;
            }
            conn.Close();
            return null;
        }

        public void UpdateBook(Book books, int id)
        {
            comm.CommandText = "update Book set CategoryId=" + books.CategoryId + ",Title='" + books.Title + "',ISBN='" + books.ISBN + "',Year=" + books.Year + ",Price=" + books.Price + ",Description='" + books.Description + "',Position='" + books.Position + "',Status='" + books.Status + "',Image='" + books.Image + "' where BookId=" + books.BookId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            conn.Close();
        }
    }
}