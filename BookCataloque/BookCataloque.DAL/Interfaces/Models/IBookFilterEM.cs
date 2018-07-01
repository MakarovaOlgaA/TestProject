using System;
using System.Collections.Generic;

namespace BookCataloque.DAL.Interfaces
{
    public interface IBookFilterEM
    {
        string Title { get; set; }

        byte? RatingLowerBound { get; set; }
        byte? RatingUpperBound { get; set; }

        DateTime? PublicationDateUpperBound { get; set; }
        DateTime? PublicationDateLowerBound { get; set; }

        short? PagesLowerBound { get; set; }
        short? PagesUpperBound { get; set; }

        string ToWhereStatement();
    }
}
