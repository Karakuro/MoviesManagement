using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(MoviesDbContext ctx, ILogger<EmployeeController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _ctx.Employees.ToList();
        }
    }
}
