using Microsoft.AspNetCore.Mvc;
using SimpleUserAPI.Models;

namespace SimpleUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new()
        {
            new User{Id=1,Name="John",Email="john@gmail.com"},
            new User{Id=2,Name="Alice",Email="alice@gmail.com"}
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if(user==null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,User user)
        {
            var u = users.FirstOrDefault(x=>x.Id==id);

            if(u==null)
                return NotFound();

            u.Name=user.Name;
            u.Email=user.Email;

            return Ok(u);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var u=users.FirstOrDefault(x=>x.Id==id);

            if(u==null)
                return NotFound();

            users.Remove(u);

            return Ok();
        }
    }
}
