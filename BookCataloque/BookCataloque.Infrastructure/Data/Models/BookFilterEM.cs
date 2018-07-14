using System;

namespace BookCataloque.Infrastructure.Data.Models
{
    public class BookFilterEM
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
