using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IUsersDAL
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<Response> InsertUser(UsersDto user);

        public Task<Users> GetById(Guid RecordId);
    }
}
