using FrontendPracticeAPI.Models;

namespace FrontendPracticeAPI.Repositories
{
    public interface IEmpRepository
    {
        //get all
        Task<IEnumerable<Employee>> Get();

        //get one
        Task<Employee> Get(int EmployeeId);

        //create
        Task<Employee> Create(Employee employee);

        //update
        Task Update (Employee employee);

        //delete
        Task Delete (int EmployeeId);
    }
}
