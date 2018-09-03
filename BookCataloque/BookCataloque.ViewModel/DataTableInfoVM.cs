using System.Collections.Generic;

namespace BookCataloque.ViewModel
{
    public class DataTableInfoVM
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        public IList<OrderVM> Order { get; set; }
        public IList<ColumnVM> Columns { get; set; }
    }
}
