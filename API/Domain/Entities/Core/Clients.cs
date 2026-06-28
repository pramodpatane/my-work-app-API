namespace API.Domain.Entities.Core
{
    public class Clients: BaseEntity
    {
        public string ClientCode { get; set; }

        public string Name { get; set; }

        public string ClientType { get; set; }

        public string Category { get; set; }

        public string ContactPerson { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string AlternateMobile { get; set; }

        public string TaxId { get; set; }
    }
}
