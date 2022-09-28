using DapperEmpCompany.Model;

namespace DapperEmpCompany.Repository.Interface
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllCompanies();
        public Task<Company> GetCompanyById(int id);
        public Task<int> CreateComapany(Company company);
        public Task UpdateCompany(Company company);
        public Task DeleteCompany(int id);
    }
}
