using CleanArchitecture.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data
{
  public class EmployeeContext : DbContext
  {
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
    public DbSet<Employee> Employees
    {
      get;
      set;
    }
  }
}
