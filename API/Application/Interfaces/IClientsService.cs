using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Application.Interfaces
{
    public interface IClientsService
    {
        Task<GridResponse<ClientsViewModel>> GetAllData(FilterData filterData);

        Task<Response> Create(Clients model);

        Task<Response> Update(Clients model);

        Task<ClientsViewModel> GetById(Guid id);

        public Task<Response> Delete(Clients model);
    }
}
