using BookCataloque.DAL.Models;
using System.Collections.Generic;

namespace BookCataloque.DAL.Interfaces
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
