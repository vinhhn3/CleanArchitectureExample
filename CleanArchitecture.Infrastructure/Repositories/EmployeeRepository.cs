using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
  public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
  {
    public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext) { }
    public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname)
    {
      return await _employeeContext.Employees.Where(m => m.LastName == lastname).ToListAsync();
    }
  }
}
