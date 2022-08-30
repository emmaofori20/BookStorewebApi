using BookStorewebApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorewebApi.SharedViewModel
{
    public class AddCategoryViewModel
    {
        public string Name { get; set; }
        public byte[] CategoryPicture { get; set; }
    }

    public class BooksInCatgoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Book> books { get; set; }
    }
}
