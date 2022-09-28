using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication14.Models
{
    public class CategorySqlImp : ICategoryRepository
    {
        SqlCommand comm;
        SqlConnection conn;

        public CategorySqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category(CategoryName,Description,Image,status, Position, CreatedAt) values ('" + category.CategoryName + "', '" + category.Description + "', '" + category.Image + "', '" + category.Status + "', '" + category.Position + "', '" + category.CreatedAt + "')"; 
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if(row>0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "Delete from Category where CategoryId="+id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int categoryid = Convert.ToInt32(reader["CategoryId"]);
                string categoryname = reader["CategoryName"].ToString();
                string description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                string position = reader["Position"].ToString();
                string createdAt = reader["CreatedAt"].ToString();
                list.Add(new Category(categoryid, categoryname, description, image, status, position, createdAt));
            }
            conn.Close();
            return list;

        }

        public Category GetCategoryById(int Catid)
        {
            comm.CommandText = "select * from Category where CategoryId="+Catid;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string name = reader["CategoryName"].ToString();
                string description= reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                string position = reader["Position"].ToString();
                string createdAt = reader["CreatedAt"].ToString();
                Category cat = new Category(id, name, description, image, status, position, createdAt);
                return cat;

            }
            conn.Close();
            return null;
        }

        public void UpdateCategory(Category category, int id)
        {
            comm.CommandText = "update Category set CategoryName='"+category.CategoryName+ "',Description='"+category.Description+ "',Image='"+category.Image+"',Status='"+category.Status+"',Position ='"+category.Position+"',CreatedAt='"+category.CreatedAt+"'where CategoryId="+category.CategoryId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            conn.Close();
      

        }
    }
}