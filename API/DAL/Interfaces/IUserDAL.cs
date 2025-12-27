using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IUsersDAL
    {
        public Task<List<Users>> GetUsersData(FilterData filterData);

        public Task<int> InsertUser(Users user);                
    }
}
