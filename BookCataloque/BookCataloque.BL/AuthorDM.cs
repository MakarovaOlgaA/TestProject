using BookCataloque.EntityModel;
using BookCataloque.Infrastructure.Business;
using BookCataloque.Infrastructure.Data;
using BookCataloque.Infrastructure.Resolving;
using BookCataloque.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCataloque.BL
{
    public class AuthorDM: BLCore, IAuthorDM
    {
        public AuthorDM(IServiceLocator serviceLocator): base(serviceLocator)
        {
        }

        public void AddAuthor(AuthorVM author)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            repo.AddAuthor(entityLocator.ConvertTo<AuthorEM>(author));
        }

        public bool DeleteAuthor(int authorID)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return repo.DeleteAuthor(authorID);
        }

        public AuthorVM GetAuthor(int authorID)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return entityLocator.ConvertTo<AuthorVM>(repo.GetAuthor(authorID));
        }

        public AuthorVM GetAuthor(string firstName, string lastName)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return entityLocator.ConvertTo<AuthorVM>(repo.GetAuthor(firstName, lastName));
        }

        public IEnumerable<AuthorVM> GetAuthors(SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();

            var result = repo.GetAuthors(searchInfo.PageSize, searchInfo.CurrentPage, out int total,
                searchInfo.OrderingInfo.ColumnName, searchInfo.OrderingInfo.DescendingOrder);

            int numPages = (int)Math.Ceiling((double)total / searchInfo.PageSize);
            filteredInfo = new FilteredInfoVM() { Total = total, Filtered = result.Count(), NumberOfPages = numPages };

            return entityLocator.ConvertTo<IEnumerable<AuthorVM>>(result);
        }

        public IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter, SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();

            var result = repo.GetAuthors(entityLocator.ConvertTo<AuthorFilterEM>(filter), searchInfo.PageSize, searchInfo.CurrentPage,
                out int total, searchInfo.OrderingInfo.ColumnName, searchInfo.OrderingInfo.DescendingOrder);

            int numPages = (int)Math.Ceiling((double)total / searchInfo.PageSize);
            filteredInfo = new FilteredInfoVM() { Total = total, Filtered = result.Count(), NumberOfPages = numPages };

            return entityLocator.ConvertTo<IEnumerable<AuthorVM>>(result);
        }


        public bool UpdateAuthor(AuthorVM author)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return repo.UpdateAuthor(entityLocator.ConvertTo<AuthorEM>(author));
        }
    }
}
