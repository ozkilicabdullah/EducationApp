using Education.Core.Models;
namespace Education.Core.DTOs
{
    public class FilterRequestDto
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
        public OrderByType orderBy { get; set; }
        public bool isOrderByDesc { get; set; }
        public FilterRequestDto()
        {
            pageNo = 1;
            pageSize = 50;
            orderBy = OrderByType.CreatedDate;
            isOrderByDesc = true;
        }
    }
}
