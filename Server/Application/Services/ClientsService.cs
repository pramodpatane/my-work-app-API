using Server.Application.DTOs;
using Server.Application.Interfaces;
using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;
using Server.Infrastructure.DAL.Interfaces;

namespace Server.Application.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsDAL _clientsDAL;
        public ClientsService(IClientsDAL clientsDAL)
        {
            _clientsDAL = clientsDAL;
        }

        public async Task<ClientsGridResponse> GetAllData(FilterData filterData)
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

        public async Task<List<DropdownModel>> GetClientsDropdown()
        {
            try
            {
                var response = await _clientsDAL.GetClientsDropdown();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
