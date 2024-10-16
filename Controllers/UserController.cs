
using Microsoft.AspNetCore.Mvc;
using StaffixAPI.Models;
using StaffixAPI.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using StaffixAPI.Entities;

namespace StaffixAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await userService.CreateUserAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get([FromRoute] int id)
        {
            var user = await userService.GetByIdAsync(id);
            if(user == null) {
                return NotFound();
            }
            return Ok(user);
        }

    }

}