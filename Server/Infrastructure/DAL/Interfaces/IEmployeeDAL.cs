using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;

namespace Server.Infrastructure.DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        public Task<GridResponse<EmployeeViewModel>> GetEmployeesData(FilterData filterData);

        public Task<EmployeeViewModel> GetById(Guid id);

        public Task<int> Create(Employee model);
        public Task<int> Update(Employee model);

        public Task<Response> Delete(Employee model);
    }
}
