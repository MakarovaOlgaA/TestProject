using System;

namespace BookCataloque.BL.Interfaces
{
    public interface IBookFilterVM
    {
        string Title { get; set; }

        byte? RatingLowerBound { get; set; }
        byte? RatingUpperBound { get; set; }

        DateTime? PublicationDateUpperBound { get; set; }
        DateTime? PublicationDateLowerBound { get; set; }

        short? PagesLowerBound { get; set; }
        short? PagesUpperBound { get; set; }
    }
}
