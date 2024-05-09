using dapperdemo.Model;

namespace dapperdemo.Repo
{
  public interface  IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int Id);
        Task<string> Create(Employee employee);

        Task<string> Update(Employee employee,int Id);
        Task<string> Remove(int Id);
    }
}
