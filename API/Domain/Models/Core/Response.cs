namespace API.Domain.Models.Core
{
    public class Response
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
