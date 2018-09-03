using BookCataloque.ViewModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Business
{
    public interface IAuthorDM
    {
        void AddAuthor(AuthorVM author);

        AuthorVM GetAuthor(int authorID);
        AuthorVM GetAuthor(string firstName, string lastName);

        IEnumerable<AuthorVM> GetAuthors();

        IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter, out int total, out int filtered);

        bool UpdateAuthor(AuthorVM author);

        bool DeleteAuthor(int authorID);
    }
}
