using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator)
    {
      _mediator = mediator;
    }

    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //public async Task<List<Employee>> Get()
    //{
    //  return await _mediator.Send(new GetAllEmployeeQuery());
    //}
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
      var result = await _mediator.Send(command);
      return Ok(result);
    }
  }
}
