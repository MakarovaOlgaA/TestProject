namespace BookCataloque.Infrastructure.Business.Models
{
    public class AuthorVM
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short NumberOfBooks { get; set; }
    }
}
