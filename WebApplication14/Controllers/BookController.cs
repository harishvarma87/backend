using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;
        public BookController()
        {
            repository = new BookSqlImp();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBooks();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetBookById(id);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(Book book, int id)
        {
            repository.UpdateBook(book, id);
            return Ok();

        }
    }
}
