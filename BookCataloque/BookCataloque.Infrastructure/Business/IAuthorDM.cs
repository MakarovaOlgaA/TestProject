using BookCataloque.ViewModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Business
{
    public interface IAuthorDM
    {
        void AddAuthor(AuthorVM author);

        AuthorVM GetAuthor(int authorID);
        AuthorVM GetAuthor(string firstName, string lastName);

        IEnumerable<AuthorVM> GetAuthors(SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo);
        IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter, SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo);

        bool UpdateAuthor(AuthorVM author);

        bool DeleteAuthor(int authorID);
    }
}
