using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorewebApi.SharedViewModel
{
    public class AddBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public IFormFile BookPicture { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }



    }
}
