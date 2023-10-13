using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }


    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
            return companies;
        }
        catch (Exception e)
        {
            _loggerManager.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {e}");
            throw;
        }
    }
}