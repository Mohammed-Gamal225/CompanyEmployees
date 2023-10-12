using Contracts;

namespace Repository;

public class CompanyRepository : RepositoryBase<CompanyRepository>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext context) : base(context)
    {
    }


}