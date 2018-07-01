using System;
using BookCataloque.BL.Interfaces;

namespace BookCataloque.BL.Models
{
    public class BookFilterVM: IBookFilterVM
    {
        public string Title { get; set; }

        public byte? RatingLowerBound { get; set; }
        public byte? RatingUpperBound { get; set; }

        public DateTime? PublicationDateUpperBound { get; set; }
        public DateTime? PublicationDateLowerBound { get; set; }

        public short? PagesLowerBound { get; set; }
        public short? PagesUpperBound { get; set; }
    }
}
