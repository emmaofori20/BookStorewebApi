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
    public class CategoryService : ICategoryService
    {
        private readonly BookStoreDBApiContext _context;

        public CategoryService(BookStoreDBApiContext context)
        {
            this._context = context;
        }
        public Category AddCategory(AddCategoryViewModel model)
        {
            var newCategory = new Category()
            {
                CategoryPicture = model.CategoryPicture,
                Name = model.Name,

            };

            _context.Category.Add(newCategory);
            _context.SaveChanges();

            return newCategory;
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

        public void DeleteCategory(Category category)
        {
           var booksInCategory= _context.Book.ToList().Where(x=>x.CategoryId == category.CategoryId);
            foreach (var item in booksInCategory)
            {
                _context.Book.Remove(item);
                _context.SaveChanges();
            }

            _context.Category.Remove(category);
            _context.SaveChanges();

        }

        public Category EditCategory(Category category)
        {
            var existingCategory = GetCategory(category.CategoryId);
            existingCategory.CategoryPicture = category.CategoryPicture;
            existingCategory.Name = category.Name;

            _context.Category.Update(existingCategory);
            _context.SaveChanges();

            return existingCategory;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        public BooksInCatgoryViewModel GetBooksInCategory(int CategoryId)
        {
            var booksInCategory = _context.Book.ToList().Where(x => x.CategoryId == CategoryId);

            var res = new BooksInCatgoryViewModel()
            {
                CategoryId = CategoryId,
                CategoryName =GetCategory(CategoryId).Name,
                books = (List<Book>)booksInCategory
            };

            return res;
        }

        public Category GetCategory(int Categoryid)
        {
            return (Category)_context.Category.Where(x => x.CategoryId == Categoryid).FirstOrDefault();
        }
    }
}
