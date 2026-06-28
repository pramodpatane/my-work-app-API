namespace API.Domain.Models.Feature
{
    public class ClientsViewModel
    {
        public Guid RecordId { get; set; }
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string ClientType { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string Category { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
