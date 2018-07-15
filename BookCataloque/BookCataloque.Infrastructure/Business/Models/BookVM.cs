using BookCataloque.Infrastructure.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCataloque.Infrastructure.Business.Models
{
    public class BookVM
    {
        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publication date is required")]
        [PastDate]
        public DateTime PublicationDate { get; set; }

        [Range(0, 10, ErrorMessage = "Rating has to be between 0 an 10")]
        public byte? Rating { get; set; }

        [Required(ErrorMessage = "Number of pages is required")]
        [Range(1, short.MaxValue, ErrorMessage = "Number of pages is either less than 1 or too large")]
        public short Pages { get; set; }

        [Required(ErrorMessage = "Book author is required.")]
        [NonEmptyCollection(ErrorMessage = "Book must have at least one author.")]
        public IEnumerable<AuthorVM> Authors { get; set; }
    }
}
