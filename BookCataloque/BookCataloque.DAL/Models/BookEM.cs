using System;
using System.Collections.Generic;
using BookCataloque.DAL.Interfaces;

namespace BookCataloque.DAL.Models
{
    class BookEM: IBookEM
    {
        public BookEM()
        {
            Authors = new List<IAuthorEM>();
        }
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte? Rating { get; set; }
        public short Pages { get; set; }
        public IList<IAuthorEM> Authors { get; set; }
    }
}
