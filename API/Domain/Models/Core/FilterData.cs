namespace API.Domain.Models.Core
{
    public class FilterData
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Pagesize { get; set; }
        public int Skip { get; set; }
        public string? FilterString { get; set; }
        public string? SortString { get; set; }
    }
}
