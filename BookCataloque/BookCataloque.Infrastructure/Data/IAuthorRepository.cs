using BookCataloque.Infrastructure.Data.Models;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Data
{
    public interface IAuthorRepository
    {
        void AddAuthor(AuthorEM author);

        AuthorEM GetAuthor(int authorID);
        IEnumerable<AuthorEM> GetAuthors();
        IEnumerable<AuthorEM> GetAuthors(AuthorFilterEM filter);

        bool UpdateAuthor(AuthorEM author);
   
        bool DeleteAuthor(int authorID);
    }
}
