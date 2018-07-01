using BookCataloque.BL.Interfaces;

namespace BookCataloque.BL.Models
{
    public class AuthorFilterVM: IAuthorFilterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
