using dapperdemo.Model;
using dapperdemo.Repo;
using Microsoft.AspNetCore.Mvc;

namespace dapperdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult>GetAll()
        {
            var _list=await this.repo.GetAll();
            if (_list != null)
            {
                return Ok( _list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var _list=await this.repo.GetById(Id);
            if(_list != null)
            {
                return Ok( _list);
            }
            else { 
            return NotFound();
            }

        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var _result =await this.repo.Create(employee);
            return Ok(_result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Employee employee,int Id)
        {
            var _result = await this.repo.Update(employee,Id);
            return Ok(_result);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int Id)
        {
            var _result = await this.repo.Remove( Id);
            return Ok(_result);
        }
    }
}
