using API.Application.DTOs;
using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Application.Interfaces
{
    public interface IClientsService
    {
        Task<ClientsGridResponse> GetAllData(FilterData filterData);

        Task<Response> Create(Clients model);

        Task<Response> Update(Clients model);

        Task<ClientsViewModel> GetById(Guid id);

        public Task<Response> Delete(Clients model);

        Task<List<DropdownModel>> GetClientsDropdown();

    }
}
