using Dapper;
using DapperEmpCompany.Context;
using DapperEmpCompany.Model;
using DapperEmpCompany.Repository.Interface;
using System.Data;

namespace DapperEmpCompany.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            var query = "SELECT * FROM company";
            using (var connection = _context.CreateConnection())
            {
                var comp = await connection.QueryAsync<Company>(query);
                companies = comp.ToList();
                foreach (var comapn in companies)
                {
                    var res = await connection.QueryAsync<Employee>("Select * from employee1 where cid=@cid", new { @cid = comapn.cid });
                    comapn.Employeelist = res.ToList();
                }
                return companies;
            }
        }       
        public async Task<Company> GetCompanyById(int id)
        {
            Company com = new Company();
            var query = "SELECT * FROM Employee where cid=@cid";
            using (var connection = _context.CreateConnection())
            {
                com = await connection.QuerySingleOrDefaultAsync<Company>(query, new { cid = id });
                
              if(com != null)
                {
                    var emp = await connection.QueryAsync<Employee>("select * from employee1x9 where cid=@cid", new { cid = id });
                    com.Employeelist = emp.ToList();
                }
                return com;
            }
        }
        public async Task<int> CreateComapany(Company company)
        {
            List<Employee> employees = new List<Employee>();
            employees = company.Employeelist.ToList();
            var query = "insert into company (cname,caddress) values (@cname,@caddress);SELECT CAST(SCOPE_IDENTITY() as int)";
            using(var connection = _context.CreateConnection())
            {
                int result = await connection.ExecuteAsync(query, company);
                foreach(var employee in company.Employeelist)
                {
                    int result1= await connection.ExecuteAsync(@"
                                    insert into employee1 (eid,cid,ename,Salary)
                                    values (@eid,@cid,@ename,@Salary)", employee);                 
                }
                return Convert.ToInt32(result); 
            }

        }
        
        public Task UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

    }
}
