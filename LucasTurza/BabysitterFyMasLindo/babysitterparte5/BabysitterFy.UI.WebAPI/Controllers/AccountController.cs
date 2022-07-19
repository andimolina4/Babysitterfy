using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;
using BabysitterFy.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterFy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        //Post
        //login
        [HttpPost("login")]
        public async Task<ActionResult<BabysitterDTO>> Login(LoginDTO login)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Username or password incorrect");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var token = _tokenService.CreateToken(user);

            //var userDto = new UserDTO()
            //{
            //    UserName = login.Username,
            //    Token = token
            //};
            var babysitterDTO = _mapper.Map<BabysitterDTO>(user);
            babysitterDTO.Token = token;

            return Ok(babysitterDTO);
        }

        //Post
        //register
        [HttpPost("register")]
        public async Task<ActionResult<BabysitterDTO>> Register(RegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            //var newUser = new AppUser()
            //{
            //    UserName = user.Username,
            //    //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
            //    //PasswordSalt = hmac.Key
            //};

            var newBabysitterDTO = _mapper.Map<Babysitter>(user);

            //var newUser = _mapper.Map<AppUser>(user);

            newBabysitterDTO.UserName = user.Username;

            var result = await _userManager.CreateAsync(newBabysitterDTO, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var token = _tokenService.CreateToken(newBabysitterDTO);

            //var userDto = new UserDTO()
            //{
            //    UserName = user.Username,
            //    Token = token
            //};

            var ownerDTO = _mapper.Map<BabysitterDTO>(newBabysitterDTO);
            ownerDTO.Token = token;

            return Ok(ownerDTO);
        }

        private bool UserExists(string username)
        {
            return _userManager.Users.Any(u => u.UserName == username);
        }
    }
}
