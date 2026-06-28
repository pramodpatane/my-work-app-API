using API.Application.Interfaces;
using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;
using API.Infrastructure.DAL.Interfaces;

namespace API.Application.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsDAL _clientsDAL;
        public ClientsService(IClientsDAL clientsDAL)
        {
            _clientsDAL = clientsDAL;
        }

        public async Task<GridResponse<ClientsViewModel>> GetAllData(FilterData filterData)
        {
            try
            {
                var result = await _clientsDAL.GetAllData(filterData);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Create(Clients model)
        {
            try
            {
                return await _clientsDAL.Create(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Update(Clients model)
        {
            try
            {
                return await _clientsDAL.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ClientsViewModel> GetById(Guid id)
        {
            try
            {
                var response = await _clientsDAL.GetById(id);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Delete(Clients employee)
        {
            try
            {
                var response = await _clientsDAL.Delete(employee);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
