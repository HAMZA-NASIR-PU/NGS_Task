using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NGS_Task.Data;
using NGS_Task.Models.Domain;
using NGS_Task.Models.DTO;

namespace NGS_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly NGSDBContext dBContext;
        public HomeController(NGSDBContext dbContext)
        {
            this.dBContext = dbContext;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto payload)
        {
            try
            {
                User user = new User()
                {
                    Email = payload.Email,
                    FirstName = payload.FirstName,
                    LastName = payload.LastName,
                    MiddleName = payload.MiddleName,
                    Password = payload.Password,
                };
                dBContext.Users.Add(user);
                dBContext.SaveChanges();
                return Ok(new { message = "User created successfully..." });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
