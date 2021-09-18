using API.Data.Repositories;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await this.userRepository.GetByIdAsync(id);
            if(user == null) { return NotFound(); }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var entityUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone
            };

            var newUser = await this.userRepository.CreateAsync(entityUser);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid) { return this.BadRequest(ModelState); }

            var oldUser = await this.userRepository.GetByIdAsync(id);
            if(oldUser == null) { return this.BadRequest("User Id don't exists."); }

            oldUser.Name = user.Name;
            oldUser.Email = user.Email;
            oldUser.Phone = user.Phone;

            var updatedUser = await this.userRepository.UpdateAsync(oldUser);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await this.userRepository.GetByIdAsync(id);
            if (user == null) { return this.NotFound(); }

            await this.userRepository.DeleteAsync(user);

            return Ok(user);
        }
    }
}
