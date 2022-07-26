using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;
using BabysitterFy.Domain.Services.TokenService;
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

            var token = await _tokenService.CreateToken(user);

            var babysitterDTO = _mapper.Map<BabysitterDTO>(user);
            babysitterDTO.Token = token;

            return Ok(babysitterDTO);
        }

        //Post
        //register
        [HttpPost("babysitter-register")]
        public async Task<ActionResult<BabysitterDTO>> BabysitterRegister(BabysitterRegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            var newBabysitter = _mapper.Map<Babysitter>(user);

            newBabysitter.UserName = user.Username;

            var result = await _userManager.CreateAsync(newBabysitter, user.Password);

            var token = await _tokenService.CreateToken(newBabysitter);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var babysitterDTO = _mapper.Map<BabysitterDTO>(newBabysitter);

            babysitterDTO.Token = token;

            return Ok(babysitterDTO);
        }

        [HttpPost("parent-register")]
        public async Task<ActionResult<ParentDTO>> ParentRegister(ParentRegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            var newParent = _mapper.Map<Parent>(user);

            newParent.UserName = user.Username;

            var result = await _userManager.CreateAsync(newParent, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var token = await _tokenService.CreateToken(newParent);

            var parentDTO = _mapper.Map<ParentDTO>(newParent);
            parentDTO.Token = token;

            return Ok(parentDTO);
        }

        private bool UserExists(string username)
        {
            return _userManager.Users.Any(u => u.UserName == username);
        }
    }
}
