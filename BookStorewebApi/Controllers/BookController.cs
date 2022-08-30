using BookStorewebApi.Models;
using BookStorewebApi.Services.IServices;
using BookStorewebApi.SharedViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStorewebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        // GET: api/<BookController>
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetBook/{id}")]

        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            if(book != null)
            {
                return Ok(book);
            }
            return NotFound($"Book with id: {id} is not found");
        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody]AddBookViewModel model)
        {
            if (ModelState.IsValid)
            {
               var res = _bookService.AddBook(model);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + res.BookId,res);
            }
            return BadRequest("Invalid Data");
        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);
            if (book != null)
            {
                _bookService.DeleteBook(book);
                return Ok("deletd Suceess");
            }
            return NotFound($"Book with id: {id} is not found");
        }
        
        [HttpPost]
        [Route("EditBook")]
        public IActionResult EditBook(Book book)
        {
            var Existingbook = _bookService.GetBook(book.BookId);
            if (Existingbook != null)
            {
               var res= _bookService.EditBook(book);
                return Ok(res);
            }
            return NotFound($"Book with id: {book.BookId} is not found");
        }
    }
}
