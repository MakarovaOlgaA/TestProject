using System.ComponentModel.DataAnnotations;

namespace BookCataloque.ViewModel
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
