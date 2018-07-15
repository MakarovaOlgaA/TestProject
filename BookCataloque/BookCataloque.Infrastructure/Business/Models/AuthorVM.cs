using System.ComponentModel.DataAnnotations;

namespace BookCataloque.Infrastructure.Business.Models
{
    public class AuthorVM
    {
        [Key]
        public int AuthorID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public short NumberOfBooks { get; set; }
    }
}
