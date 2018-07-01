namespace BookCataloque.DAL.Interfaces
{
    public interface IAuthorEM
    {
        int AuthorID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        short NumberOfBooks { get; set; }
    }
}
