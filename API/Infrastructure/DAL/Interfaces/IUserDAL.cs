using API.Application.DTOs;
using API.Domain.Entities.Core;
using API.Domain.Models.Core;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IUsersDAL
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<Response> InsertUser(UsersDto user);

        public Task<Users> GetById(Guid RecordId);
    }
}
