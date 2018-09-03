using BookCataloque.Infrastructure.Data;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BookCataloque.EntityModel;

namespace BookCataloque.DAL
{
    public class AuthorRepository: DALCore, IAuthorRepository
    {
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

        public AuthorEM GetAuthor(string firstName, string lastName)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorEM>("USP_GetAuthorByName", new { firstName, lastName }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<AuthorEM> GetAuthors()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<AuthorEM>("USP_GetAuthors", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<AuthorEM> GetAuthors(AuthorFilterEM filter, int pageSize,int pageNumber, out int total, string sortColumn = null, bool descendingSortOrder = false)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var spParams = new DynamicParameters();
                spParams.Add("PageSize", pageSize);
                spParams.Add("PageNumber", pageNumber);

                if (sortColumn != null)
                {
                    spParams.Add("SortColumn", sortColumn);
                    spParams.Add("DescendingOrder", descendingSortOrder);
                }

                spParams.Add("Total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                spParams.AddDynamicParams(filter);

                var result = db.Query<AuthorEM>("USP_GetAuthors", spParams, commandType: CommandType.StoredProcedure).ToList();

                total = spParams.Get<int>("Total");

                return result;
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
