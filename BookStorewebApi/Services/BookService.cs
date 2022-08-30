using BookStorewebApi.Models;
using BookStorewebApi.Services.IServices;
using BookStorewebApi.SharedViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorewebApi.Services
{
    public class BookService:IBookService
    {
        private readonly BookStoreDBApiContext _context;

        public BookService(BookStoreDBApiContext context)
        {
            this._context = context;
        }

        public Book AddBook(AddBookViewModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                CategoryId = model.CategoryId,
                BookPicture = Convertimage(model.BookPicture),
                Description = model.Description,
                Name = model.Name,
                Price = model.Price

            };

            _context.Book.Add(newBook);
            _context.SaveChanges();

            return newBook;
        }

        public void DeleteBook(Book model)
        {
            _context.Book.Remove(model);
            _context.SaveChanges();
        }

        public Book EditBook(Book model)
        {
            var existingbook = GetBook(model.BookId);
            existingbook.Author = model.Author;
            existingbook.BookPicture = model.BookPicture;
            existingbook.CategoryId = model.CategoryId;
            existingbook.Description = model.Description;
            existingbook.Name = model.Name;

            _context.Book.Update(existingbook);
            _context.SaveChanges();

            return existingbook;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Book.ToList();
        }

        public Book GetBook(int Id)
        {
            return _context.Book.FirstOrDefault(x => x.BookId == Id);
        }

        private byte[] Convertimage(IFormFile formFile)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                fileBytes = stream.ToArray();
            }

            return fileBytes;
        }
    }
}
