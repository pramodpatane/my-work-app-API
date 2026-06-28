using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IClientsDAL
    {
        Task<GridResponse<ClientsViewModel>> GetAllData(FilterData filterData);

        Task<Response> Create(Clients model);

        Task<Response> Update(Clients model);

        Task<ClientsViewModel> GetById(Guid id);

        public Task<Response> Delete(Clients model);
    }
}
