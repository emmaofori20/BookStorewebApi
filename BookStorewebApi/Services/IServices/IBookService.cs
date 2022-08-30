using BookStorewebApi.Models;
using BookStorewebApi.SharedViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorewebApi.Services.IServices
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int Id);
        public Book EditBook(Book model);
        public void DeleteBook(Book model);
        public Book AddBook(AddBookViewModel model);
       
    }
}
