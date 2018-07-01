namespace BookCataloque.DAL.Interfaces
{
    public interface IAuthorFilterEM
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string ToWhereStatement();
    }
}
