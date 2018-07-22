namespace BookCataloque.ViewModel
{
    public class SearchInfoVM
    {
        public SearchInfoVM()
        {
            CurrentPage = 1;
            OrderingInfo = new OrderingInfoVM();
        }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public OrderingInfoVM OrderingInfo { get; set; }
    }
}
