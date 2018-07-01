using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BookCataloque.DAL.Interfaces;
using BookCataloque.DAL.Models;
using Dapper;

namespace BookCataloque.DAL
{
    public class CataloqueRepository : ICataloqueRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public void AddAuthor(IAuthorEM author)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [Authors] ([FirstName], [LastName])
                                 VALUES (@FirstName, @LastName)";
                db.Execute(query, new { author.FirstName, author.LastName });
            }
        }

        public void AddBook(IBookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [Books] ([Title], [PublicationDate], [Pages])
                                 OUTPUT inserted.BookID
                                 VALUES (@Title, '@PublicationDate', @Pages)";
                book.BookID = (int) db.ExecuteScalar(query, new
                {
                    book.Title,
                    book.PublicationDate,
                    book.Pages
                });

                if (book.Authors != null && book.Authors.Count() != 0)
                {
                    InsertBookAuthors(book);
                }
            }
        }

        public bool DeleteAuthor(int authorID)
        {
            bool success = false;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [Authors] WHERE AuthorID = @AuthorID";
                success = db.Execute(query, new { authorID }) == 0 ? false : true;
            }
            return success;
        }

        public bool DeleteBook(int bookID)
        {
            bool success = false;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [Books] WHERE BookID = @BookID";
                success = db.Execute(query, new { bookID }) == 0 ? false : true;
            }
            return success;
        }

        public IAuthorEM GetAuthor(int authorID)
        {
            IAuthorEM author;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"SELECT [AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Authors]
                                 WHERE AuthorID = @AuthorID";
                author = db.Query<AuthorEM>(query, new { authorID }).FirstOrDefault();
            }
            return author;
        }

        public IEnumerable<IAuthorEM> GetAuthors()
        {
            IEnumerable<IAuthorEM> authors;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"SELECT [AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Authors]
                                 ORDER BY LastName";
                authors = db.Query<AuthorEM>(query).ToList();
            }
            return authors;
        }

        public IEnumerable<IAuthorEM> GetAuthors(IAuthorFilterEM filter)
        {
            IEnumerable<IAuthorEM> authors;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = String.Format(@"SELECT [AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Authors]
                                 {0}
                                 ORDER BY LastName", filter.ToWhereStatement());
                authors = db.Query<AuthorEM>(query).ToList();
            }
            return authors;
        }

        public IBookEM GetBook(int bookID)
        {
            IBookEM foundBook;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"SELECT [Books].[BookID], [Title], [PublicationDate], [Rating], [Pages], 
                                 [Authors].[AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Books]
                                 INNER JOIN [BookAuthors] ON [BookAuthors].[BookID] = [Books].[BookID]
                                 INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
                                 WHERE [Books].[BookID] = @BookID";
                foundBook = db.Query<BookEM, AuthorEM, BookEM>(query, (book, author) => { book.Authors.Add(author); return book; },
                    new { bookID }, splitOn: "AuthorID").FirstOrDefault();
            }
            return foundBook;
        }

        public IEnumerable<IBookEM> GetBooks()
        {
            IEnumerable<IBookEM> books;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"SELECT [Books].[BookID], [Title], [PublicationDate], [Rating], [Pages], 
                                 [Authors].[AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Books]
                                 INNER JOIN [BookAuthors] ON [BookAuthors].[BookID] = [Books].[BookID]
                                 INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
                                 ORDER BY [Title]";
                books = db.Query<BookEM, AuthorEM, BookEM>(query, (book, author) => { book.Authors.Add(author); return book; },
                    splitOn: "AuthorID").ToList();
            }
            return books;
        }

        public IEnumerable<IBookEM> GetBooks(IBookFilterEM filter)
        {
            IEnumerable<IBookEM> books;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = String.Format(@"SELECT [Books].[BookID], [Title], [PublicationDate], [Rating], [Pages], 
                                 [Authors].[AuthorID], [FirstName], [LastName], [NumberOfBooks]
                                 FROM [Books]
                                 {0}
                                 INNER JOIN [BookAuthors] ON [BookAuthors].[BookID] = [Books].[BookID]
                                 INNER JOIN [Authors] ON [Authors].[AuthorID] = [BookAuthors].[AuthorID]
                                 ORDER BY [Title]", filter.ToWhereStatement());
                books = db.Query<BookEM, AuthorEM, BookEM>(query, (book, author) => { book.Authors.Add(author); return book; },
                    splitOn: "AuthorID").ToList();
            }
            return books;
        }

        public bool UpdateAuthor(IAuthorEM author)
        {
            bool success = false;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [Authors] 
                                 SET [FirstName] = @FirstName, [LastName] = @LastName
                                 WHERE AuthorID = @AuthorID";
                success = db.Execute(query, new { author.FirstName, author.LastName, author.AuthorID }) == 0 ? false : true;
            }
            return success;
        }

        public bool UpdateBook(IBookEM book)
        {
            bool success = false;
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [Books] 
                                 SET [Title] = @Title, [PublicationDate] = @PublicationDate, [Pages] = @Pages
                                 WHERE BookID = @BookID";
                success = db.Execute(query, new
                {
                    book.Title,
                    book.PublicationDate,
                    book.Pages,
                    book.BookID
                }) == 0 ? false : true;

                query = @"DELETE FROM [BookAuthors] WHERE BookID = @BookID";
                db.Execute(query, new { book.BookID });

                if (book.Authors != null && book.Authors.Count() != 0)
                {
                    InsertBookAuthors(book);
                }
            }
            return success;
        }

        private void InsertBookAuthors(IBookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var bookAuthorsList = book.Authors.Select(a => new { book.BookID, a.AuthorID });
                string query = @"INSERT INTO [BookAuthors] ([BookID], [AuthorID])
                              VALUES (@BookID, @AuthorID)";
                db.Execute(query, bookAuthorsList);
            }
        }
    }
}
