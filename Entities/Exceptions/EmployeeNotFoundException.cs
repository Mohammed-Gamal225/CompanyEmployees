namespace Entities.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid id) : base($"Employee with id:{id} Not Found")
    {
    }
}