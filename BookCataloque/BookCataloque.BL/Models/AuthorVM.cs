using BookCataloque.BL.Interfaces;

namespace BookCataloque.BL.Models
{
    public class AuthorVM : IAuthorVM
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short NumberOfBooks { get; set; }
    }
}
