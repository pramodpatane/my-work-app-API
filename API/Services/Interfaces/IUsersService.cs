using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<Response> InsertUser(UsersDto user);

        public Task<Users> GetById(Guid RecordId);

    }
}
