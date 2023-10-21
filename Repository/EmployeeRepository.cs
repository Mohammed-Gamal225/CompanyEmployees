using Contracts;
using Entities.Models;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext context) : base(context)
    {
    }

    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
    FindByCondition(e => e.CompanyId == companyId, trackChanges)
        .OrderBy(e => e.Name).ToList();

    public Employee GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) =>
        FindByCondition(e => e.CompanyId == companyId && e.Id == employeeId, trackChanges).SingleOrDefault()!;

    public void CreateEmployee(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;

        Create(employee);
    }
}