namespace BookCataloque.BL.Interfaces
{
    public interface IAuthorVM
    {
        int AuthorID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        short NumberOfBooks { get; set; }
    }
}
