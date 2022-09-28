using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;
        public CategoryController()
        {
            repository = new CategorySqlImp();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Category category, int id)
        {
            repository.UpdateCategory(category ,id);
            return Ok();

        }


    }
}
