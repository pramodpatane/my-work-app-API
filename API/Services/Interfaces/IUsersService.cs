using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<int> InsertUser(Users user);

    }
}
