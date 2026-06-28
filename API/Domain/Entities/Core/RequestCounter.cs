namespace API.Domain.Entities.Core
{
    public class RequestCounter
    {
        public int Id { get; set; }
        public string Path { get; set; }        
        public string Method { get; set; }      
        public DateTime RequestedAt { get; set; }
    }
}
