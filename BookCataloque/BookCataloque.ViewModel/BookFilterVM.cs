using BookCataloque.Infrastructure.Extensions.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookCataloque.ViewModel
{
    public class BookFilterVM
    {
        public string Title { get; set; }

        [Range(0, 10, ErrorMessage = "Rating has to be between 0 an 10")]
        public byte? RatingLowerBound { get; set; }

        [Range(0, 10, ErrorMessage = "Rating has to be between 0 an 10")]
        public byte? RatingUpperBound { get; set; }

        [PastDate]
        public DateTime? PublicationDateUpperBound { get; set; }

        [PastDate]
        public DateTime? PublicationDateLowerBound { get; set; }

        [Range(1, short.MaxValue, ErrorMessage = "Number of pages is either less than 1 or too large")]
        public short? PagesLowerBound { get; set; }

        [Range(1, short.MaxValue, ErrorMessage = "Number of pages is either less than 1 or too large")]
        public short? PagesUpperBound { get; set; }
    }
}
