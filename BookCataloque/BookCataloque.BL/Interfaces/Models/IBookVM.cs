using System;
using System.Collections.Generic;

namespace BookCataloque.BL.Interfaces
{
    public interface IBookVM
    {
        int BookID { get; set; }
        string Title { get; set; }
        DateTime PublicationDate { get; set; }
        byte? Rating { get; set; }
        short Pages { get; set; }
        IEnumerable<IAuthorVM> Authors { get; set; }
    }
}
