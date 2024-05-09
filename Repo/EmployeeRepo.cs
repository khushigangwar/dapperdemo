
using dapperdemo.Model;
using dapperdemo.Model.Data;
using Dapper;
using System.Data;
namespace dapperdemo.Repo
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly DapperDbContext context;

         public EmployeeRepo(DapperDbContext context)
        {
            this.context = context;
        }

        public async Task<string>Create(Employee employee)
        {
            string response = string.Empty;
            string query = "Insert into employee(name,email,phone,designation) values (@name,@email,@phone,@designation)";
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("email", employee.Email, DbType.String);
            parameters.Add("phone", employee.Phone, DbType.String);
            parameters.Add("Designation", employee.Designaion, DbType.String);
            using(var connectin = this.context.CreateConnection())
            {
               await connectin.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        public async Task<List<Employee>> GetAll()
        {
            string query = "Select * from employee";
            using var connectin = this.context.CreateConnection();

            var emplist = await connectin.QueryAsync<Employee>(query);

            return emplist.ToList();
        }
        public async Task<Employee> GetById(int Id)
        {
            string query = "Select  * from employee where id=@id";
            using var connectin = this.context.CreateConnection();

            var emplist = await connectin.QueryFirstOrDefaultAsync<Employee>(query, new { Id });

            return emplist;

        }
        public async Task<string> Remove(int Id)
        {
            string response=string.Empty;
            string query = "Delete from employee where id=@id";
            using var connectin = this.context.CreateConnection();
            {
                var emplist = await connectin.ExecuteAsync(query, new { Id });
                response = "pass";
            }
            return response;
        }

    
        public async Task<string> Update(Employee employee, int Id)
        {
            string response = string.Empty;
            string query = "Update employee set name=@name,email=@email,phone=@phone,designation=@designation";
            var parameters= new DynamicParameters();
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("email", employee.Email, DbType.String);
            parameters.Add("phone", employee.Phone, DbType.String);
            parameters.Add("Designation", employee.Designaion, DbType.String);
            using (var connectin = this.context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }


    }
}
