using BookCataloque.DAL.Interfaces;
using System;
using System.Text;

namespace BookCataloque.DAL.Models
{
    public class AuthorFilterEM: IAuthorFilterEM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ToWhereStatement()
        {
            StringBuilder whereStatement = new StringBuilder();
            whereStatement.Append("WHERE");

            if (FirstName != null)
            {
                whereStatement.AppendFormat(" [FirstName] LIKE('%{0}%') AND", FirstName);
            }

            if (LastName != null)
            {
                whereStatement.AppendFormat(" [LastName] LIKE('%{0}%')", LastName);
            }

            if (whereStatement.ToString(0, whereStatement.Length - 3) == "AND")
            {
                whereStatement.Remove(whereStatement.Length - 3, 3);
            }

            string result = whereStatement.ToString();
            return result.EndsWith("WHERE") ? String.Empty : result;
        }
    }
}
