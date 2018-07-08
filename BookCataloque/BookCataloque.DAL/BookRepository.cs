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
    public class BookRepository : IBookRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public void AddBook(BookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var authors = ToDataTableList(book.Authors, "AuthorID", typeof(int));
                db.Execute("USP_InsertBook", new { book.Title, book.PublicationDate, book.Pages, book.Rating, authors }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool DeleteBook(int bookID)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                int rowsAffected = db.Execute("USP_DeleteBook", new { bookID }, commandType: CommandType.StoredProcedure);
                return rowsAffected != 0;
            }
        }
      
        public BookEM GetBook(int bookID)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BookEM, AuthorEM, BookEM>("USP_GetBook", (book, author) => { book.Authors.Add(author); return book; },
                    new { bookID }, splitOn: "AuthorID", commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<BookEM> GetBooks()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BookEM, AuthorEM, BookEM>("USP_GetBooks", (book, author) => { book.Authors.Add(author); return book; },
                    splitOn: "AuthorID", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<BookEM> GetBooks(BookFilterEM filter)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BookEM, AuthorEM, BookEM>("USP_GetBooks", (book, author) => { book.Authors.Add(author); return book; }, splitOn: "AuthorID",
                    param: new { filter.Title, filter.RatingLowerBound, filter.RatingUpperBound, filter.PublicationDateLowerBound, filter.PublicationDateUpperBound, filter.PagesLowerBound, filter.PagesUpperBound },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public bool UpdateBook(BookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var authors = ToDataTableList(book.Authors, "AuthorID", typeof(int));
                int rowsAffecred = db.Execute("USP_UpdateBook", new { book.BookID, book.Title, book.PublicationDate, book.Pages, book.Rating, authors }, commandType: CommandType.StoredProcedure);
                return rowsAffecred != 0;
            }
        }

        private DataTable ToDataTableList(IEnumerable<object> list, string columnName, Type columnType)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                DataTable dtList = new DataTable();
                dtList.Columns.Add(columnName, columnType);

                foreach (var item in list)
                {
                    dtList.Rows.Add(item);
                }

                return dtList;
            }
        }
    }
}
