namespace Server.Domain.Models.Core
{
    public class GridResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();

        public int TotalCount { get; set; }
    }
}
