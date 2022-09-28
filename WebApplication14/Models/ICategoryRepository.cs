using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    internal interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        void UpdateCategory(Category category, int id);
        void DeleteCategory(int id);

    }
}
