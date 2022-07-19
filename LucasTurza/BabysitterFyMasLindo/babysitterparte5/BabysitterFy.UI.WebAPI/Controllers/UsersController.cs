using BabysitterFy.Data.Data;
using BabysitterFy.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterFy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BabysitterFyDbContext _context;

        public UsersController(BabysitterFyDbContext context)
        {
            _context = context;
        }

        //Get
        //GetUsers
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //Get
        //GetUserById
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return Ok(_context.Users.Find(id));
        }
    }
}
