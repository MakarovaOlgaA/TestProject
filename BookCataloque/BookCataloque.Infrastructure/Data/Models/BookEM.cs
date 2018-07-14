using System;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Data.Models
{
    public class BookEM
    {
        public BookEM()
        {
            Authors = new List<AuthorEM>();
        }
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte? Rating { get; set; }
        public short Pages { get; set; }
        public IList<AuthorEM> Authors { get; set; }
    }
}
