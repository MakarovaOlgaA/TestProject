using BookCataloque.DAL.Interfaces;

namespace BookCataloque.DAL.Models
{
    public class AuthorEM : IAuthorEM
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short NumberOfBooks { get; set; }
    }
}
