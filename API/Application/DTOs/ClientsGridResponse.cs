using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Application.DTOs
{
    public class ClientsGridResponse: GridResponse<ClientsViewModel>
    {
        public int ThisMonthTotal { get; set; }
    }
}
