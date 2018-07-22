using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace BookCataloque.DAL
{
    public class DALCore
    {
        protected readonly string connectionString;

        public DALCore()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        protected DataTable ToDataTableList(IEnumerable<object> list, string columnName, Type columnType)
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
