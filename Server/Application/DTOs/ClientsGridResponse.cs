using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;

namespace Server.Application.DTOs
{
    public class ClientsGridResponse: GridResponse<ClientsViewModel>
    {
        public int ThisMonthTotal { get; set; }
    }
}
