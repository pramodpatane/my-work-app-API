using Server.Application.DTOs;
using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;

namespace Server.Infrastructure.DAL.Interfaces
{
    public interface IClientsDAL
    {
        Task<ClientsGridResponse> GetAllData(FilterData filterData);

        Task<Response> Create(Clients model);

        Task<Response> Update(Clients model);

        Task<ClientsViewModel> GetById(Guid id);

        public Task<Response> Delete(Clients model);

        Task<List<DropdownModel>> GetClientsDropdown();
    }
}
