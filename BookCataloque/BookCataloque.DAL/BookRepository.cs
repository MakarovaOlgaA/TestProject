using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BookCataloque.Infrastructure.Data;
using Dapper;
using BookCataloque.EntityModel;

namespace BookCataloque.DAL
{
    public class BookRepository : DALCore, IBookRepository
    {
        public void AddBook(BookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var authors = ToDataTableList(book.Authors, "AuthorID", typeof(int));

                var spParams = new DynamicParameters();
                spParams.Add("Authors", authors);
                spParams.AddDynamicParams(book);

                db.Execute("USP_InsertBook", spParams, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<BookEM> GetBooks(int pageSize, int pageNumber, out int total, string sortColumn, bool descendingSortOrder = false)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var spParams = new DynamicParameters();
                spParams.Add("PageSize", pageSize);
                spParams.Add("PageNumber", pageNumber);
                spParams.Add("SortColumn", sortColumn);
                spParams.Add("DescendingOrder", descendingSortOrder);
                spParams.Add("Total", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var result =  db.Query<BookEM, AuthorEM, BookEM>("USP_GetBooks", (book, author) => { book.Authors.Add(author); return book; },
                    spParams, splitOn: "AuthorID", commandType: CommandType.StoredProcedure).ToList();

                total = spParams.Get<int>("Total");

                return result;
            }
        }

        public IEnumerable<BookEM> GetBooks(BookFilterEM filter)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var spParams = new DynamicParameters();
                spParams.AddDynamicParams(filter);

                return db.Query<BookEM, AuthorEM, BookEM>("USP_GetBooks", (book, author) => { book.Authors.Add(author); return book; }, spParams, 
                    splitOn: "AuthorID", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<BookEM> GetBooks(BookFilterEM filter, int pageSize, int pageNumber, out int total, string sortColumn, bool descendingSortOrder = false)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var spParams = new DynamicParameters();
                spParams.Add("PageSize", pageSize);
                spParams.Add("PageNumber", pageNumber);
                spParams.Add("SortColumn", sortColumn);
                spParams.Add("DescendingOrder", descendingSortOrder);
                spParams.Add("Total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                spParams.AddDynamicParams(filter);

                var result = db.Query<BookEM, AuthorEM, BookEM>("USP_GetBooks", (book, author) => { book.Authors.Add(author); return book; },
                   spParams, splitOn: "AuthorID", commandType: CommandType.StoredProcedure).ToList();

                total = spParams.Get<int>("Total");

                return result;
            }
        }

        public bool UpdateBook(BookEM book)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var authors = ToDataTableList(book.Authors, "AuthorID", typeof(int));

                var spParams = new DynamicParameters();
                spParams.Add("Authors", authors);
                spParams.AddDynamicParams(book);

                int rowsAffecred = db.Execute("USP_UpdateBook", spParams, commandType: CommandType.StoredProcedure);
                return rowsAffecred != 0;
            }
        }
    }
}
