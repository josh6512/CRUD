using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication121212.data;
using WebApplication121212.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication121212.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepository<User> repository;

        public UserController(IUserRepository<User> repository)
        {
            this.repository = repository;
        }

     

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await repository.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetUserById(id));
        }

      
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] User user)
        {
           return Ok(await repository.AddUser(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put( [FromBody] User user,int id)
        {
           return Ok(await repository.UpdateUser(user,id));
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult>Delete(int id)
        {
         return Ok( await  repository.RemoveUser(id));
        }
    }
}
