using System;
using System.Collections.Generic;
using BookCataloque.BL.Interfaces;

namespace BookCataloque.BL.Models
{
    public class BookVM: IBookVM
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte? Rating { get; set; }
        public short Pages { get; set; }
        public IEnumerable<IAuthorVM> Authors { get; set; }
    }
}
