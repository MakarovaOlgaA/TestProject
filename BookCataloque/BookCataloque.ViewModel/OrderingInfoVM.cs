namespace BookCataloque.ViewModel
{
    public class OrderingInfoVM
    {
        public OrderingInfoVM()
        {
            DescendingOrder = false;
        }

        public string ColumnName { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
