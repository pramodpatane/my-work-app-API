using Server.Application.DTOs;
using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IUsersService
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<Response> InsertUser(UsersDto user);

        public Task<Users> GetById(Guid RecordId);

    }
}
