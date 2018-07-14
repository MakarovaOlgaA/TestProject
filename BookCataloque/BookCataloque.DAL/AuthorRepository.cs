using BookCataloque.Infrastructure.Data.Models;
using BookCataloque.Infrastructure.Data;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookCataloque.DAL
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public void AddAuthor(AuthorEM author)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Execute("USP_InsertAuthor", new { author.FirstName, author.LastName }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool DeleteAuthor(int authorID)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                int rowsAffected = db.Execute("USP_DeleteAuthor", new { authorID }, commandType: CommandType.StoredProcedure);
                return rowsAffected != 0;
            }
        }

        public AuthorEM GetAuthor(int authorID)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorEM>("USP_GetAuthor", new { authorID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<AuthorEM> GetAuthors()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorEM>("USP_GetAuthors", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<AuthorEM> GetAuthors(AuthorFilterEM filter)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorEM>("USP_GetAuthors", new { filter.FirstName, filter.LastName }, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public bool UpdateAuthor(AuthorEM author)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                int rowsAffected = db.Execute("USP_UpdateAuthor", new { author.AuthorID, author.FirstName, author.LastName }, commandType: CommandType.StoredProcedure);
                return rowsAffected != 0;
            }
        }
    }
}
