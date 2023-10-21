using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers;
[Route("Api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public EmployeesController(IServiceManager serviceManager)
    {
        this._serviceManager = serviceManager;
    }

    [HttpGet]
    public IActionResult GetEmployees(Guid companyId)
    {
        var employees = _serviceManager.EmployeeService.GetEmployees(companyId, trackChanges: false);

        return Ok(employees);
    }


    [HttpGet("{id:guid}", Name = "GetEmployee")]
    public IActionResult GetEmployee(Guid companyId, Guid id)
    {
        var employee = _serviceManager.EmployeeService.GetEmployee(companyId, id, trackChanges: false);

        return Ok(employee);
    }

    [HttpPost]

    public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employeeForCreation)
    {
        if (employeeForCreation is null)
            return BadRequest("Employee Object is null");
        var employeToReturn =
            _serviceManager.EmployeeService.CreateEmployeeForCompany(companyId, employeeForCreation,
                trackChanges: false);
        return CreatedAtRoute("GetEmployee", new { companyId, employeToReturn.Id }, employeToReturn);

    }
}