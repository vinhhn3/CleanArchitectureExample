using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Application.Responses;
using CleanArchitecture.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handlers
{
  public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
  {
    private readonly IEmployeeRepository _employeeRepo;
    public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
    {
      _employeeRepo = employeeRepository;
    }
    public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
      var employeeEntitiy = EmployeeMapper.Mapper.Map<Employee>(request);
      if (employeeEntitiy is null)
      {
        throw new ApplicationException("Issue with mapper");
      }
      var newEmployee = await _employeeRepo.AddAsync(employeeEntitiy);
      var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
      return employeeResponse;
    }
  }
}
