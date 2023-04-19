using FrontendPracticeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontendPracticeAPI.Repositories
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }


        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int EmployeeId)
        {
            return await _context.Employees.FindAsync(EmployeeId);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int EmployeeId)
        {
            var employeeToDelete = await _context.Employees.FindAsync(EmployeeId);
            _context.Employees.Remove(employeeToDelete);

            await _context.SaveChangesAsync();
        }

    }
}
