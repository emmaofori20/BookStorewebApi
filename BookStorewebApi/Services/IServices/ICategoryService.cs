using BookStorewebApi.Models;
using BookStorewebApi.SharedViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorewebApi.Services.IServices
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategory(int Categoryid);
        public void DeleteCategory(Category category);
        public Category EditCategory(Category category);
        public Category AddCategory(AddCategoryViewModel model);
        public BooksInCatgoryViewModel GetBooksInCategory(int CategoryId);
    }
}
