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
       
        public IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter, out int total, out int filtered)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            IEnumerable<AuthorEM> result;

            if (filter.Order.Count != 0)
            {
                string columName = filter.Columns[filter.Order.First().Column].Name;
                bool descOrder = filter.Order.First().Dir.ToUpper() == "DESC";

                var tmp = entityLocator.ConvertTo<AuthorFilterEM>(filter);
                result = repo.GetAuthors(entityLocator.ConvertTo<AuthorFilterEM>(filter), filter.Length, filter.Start, out total, columName, descOrder);
            }
            else
            {
                result = repo.GetAuthors(entityLocator.ConvertTo<AuthorFilterEM>(filter), filter.Length, filter.Start, out total);
            }

            filtered = result.Count();

            return entityLocator.ConvertTo<IEnumerable<AuthorVM>>(result);
        }


        public bool UpdateAuthor(AuthorVM author)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return repo.UpdateAuthor(entityLocator.ConvertTo<AuthorEM>(author));
        }
    }
}
