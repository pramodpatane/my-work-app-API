using API.Application.DTOs;
using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IUsersService
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<Response> InsertUser(UsersDto user);

        public Task<Users> GetById(Guid RecordId);

    }
}
