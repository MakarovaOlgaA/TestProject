using System;
using System.Collections.Generic;

namespace BookCataloque.DAL.Interfaces
{
    public interface IBookEM
    {
        int BookID { get; set; }
        string Title { get; set; }
        DateTime PublicationDate { get; set; }
        byte? Rating { get; set; }
        short Pages { get; set; }
        IList<IAuthorEM> Authors { get; set; }
    }
}
