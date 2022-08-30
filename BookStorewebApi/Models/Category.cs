using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStorewebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public byte[] CategoryPicture { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
