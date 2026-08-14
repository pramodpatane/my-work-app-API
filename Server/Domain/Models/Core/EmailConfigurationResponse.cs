namespace Server.Domain.Models.Core
{
    public class EmailConfigurationResponse
    {
        public string? FromEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
