using System;
using System.Collections.Generic;
using System.Text;
using BookCataloque.DAL.Interfaces;

namespace BookCataloque.DAL.Models
{
    public class BookFilterEM: IBookFilterEM
    {
        public string Title { get; set; }

        public byte? RatingLowerBound { get; set; }
        public byte? RatingUpperBound { get; set; }

        public DateTime? PublicationDateUpperBound { get; set; }
        public DateTime? PublicationDateLowerBound { get; set; }

        public short? PagesLowerBound { get; set; }
        public short? PagesUpperBound { get; set; }

        public string ToWhereStatement()
        {
            StringBuilder whereStatement = new StringBuilder();
            whereStatement.Append("WHERE");

            if (Title != null)
            {
                whereStatement.AppendFormat(" [Title] LIKE('%{0}%') AND", Title);
            }

            if (RatingLowerBound.HasValue)
            {
                whereStatement.AppendFormat(" [Rating] >= {0} AND", RatingLowerBound.Value);
            }

            if (RatingUpperBound.HasValue)
            {
                whereStatement.AppendFormat(" [Rating] <= {0} AND", RatingUpperBound.Value);
            }

            if (PublicationDateLowerBound.HasValue)
            {
                whereStatement.AppendFormat(@" [PublicationDate] >= '{0}' AND", PublicationDateLowerBound.Value.ToString("yyyy-MM-dd"));
            }

            if (PublicationDateUpperBound.HasValue)
            {
                whereStatement.AppendFormat(@" [PublicationDate] <= '{0}' AND", PublicationDateUpperBound.Value.ToString("yyyy-MM-dd"));
            }

            if (PagesLowerBound.HasValue)
            {
                whereStatement.AppendFormat(" [Pages] >= {0} AND", PagesLowerBound.Value);
            }

            if (PagesUpperBound.HasValue)
            {
                whereStatement.AppendFormat(" [Pages] <= {0} AND", PagesUpperBound.Value);
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
