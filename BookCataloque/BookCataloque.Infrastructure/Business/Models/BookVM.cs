using System;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Business.Models
{
    public class BookVM
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte? Rating { get; set; }
        public short Pages { get; set; }
        public IEnumerable<AuthorVM> Authors { get; set; }
    }
}
