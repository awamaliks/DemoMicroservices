using Microsoft.AspNetCore.Mvc;
using UserService.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Sample static data for demo
        private static List<User> Users = new List<User> { new User { Name = "Alice" }, new User { Name = "Bob" }, new User { Name = "Charlie" } };

        // Get all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(Users);
        }

        // Get a specific user by name
        [HttpGet("{name}")]
        public IActionResult GetUser(string name)
        {
            var user = Users.Find(u => u.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (user == null)
                return NotFound("User not found.");
            return Ok(user);
        }

        // Add a new user
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            Users.Add(user);
            return Ok();
        }
    }
}

