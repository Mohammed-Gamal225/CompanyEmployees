﻿using Contracts;
using Entities.Models;

namespace Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext context) : base(context)
    {
    }


    public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
    FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();

    public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(c => ids.Contains(c.Id), trackChanges)
            .ToList();

    public Company GetCompany(Guid companyId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault()!;

    public void CreateCompany(Company company) => Create(company);
}