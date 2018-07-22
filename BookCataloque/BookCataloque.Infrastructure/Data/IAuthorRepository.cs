using BookCataloque.EntityModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Data
{
    public interface IAuthorRepository
    {
        void AddAuthor(AuthorEM author);

        AuthorEM GetAuthor(string firstName, string lastName);
        AuthorEM GetAuthor(int authorID);

        IEnumerable<AuthorEM> GetAuthors();
        IEnumerable<AuthorEM> GetAuthors(int pageSize, int pageNumber, out int total, string sortColumn, bool descendingSortOrder = false);

        IEnumerable<AuthorEM> GetAuthors(AuthorFilterEM filter);
        IEnumerable<AuthorEM> GetAuthors(AuthorFilterEM filter, int pageNumber, int pageSize, out int total, string sortColumn, bool descendingSortOrder = false);

        bool UpdateAuthor(AuthorEM author);
   
        bool DeleteAuthor(int authorID);
    }
}
