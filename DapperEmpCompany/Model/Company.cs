namespace DapperEmpCompany.Model
{
    public class Company
    {
        public int cid { get; set; }
        public string cname { get; set; }
        public string caddress { get; set; }
        public List<Employee> Employeelist { get; set; }
    }

    public class InsertCompany
    {
        public int cid { get; set; }
        public string? cname { get; set; }
        public string? caddress { get; set; }
        public List<Employee> Employeelist { get; set; }
    }
    public class UpdateCompany
    {
        public string? cname { get; set; }
        public string? caddress { get; set; }
        public List<Employee> Employeelist { get; set; }
    }
}
