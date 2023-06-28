using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rescuit.API.CustomAttribute;
using Rescuit.API.Models;
using Rescuit.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rescuit.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;
        public RecruitController(ITokenRepository tokenRepository, IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _configuration = configuration;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<string> Get()
        {
            var recruits = new List<string>
        {
            "John Doe",
            "Jane Doe",
            "Junior Doe"
        };

            return recruits;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }


        // GET: api/<UsersController>
        [HttpGet]
        [Route("authorizetest")]
        [CustomAuthorize("admin")]
        public IActionResult GetWithAuthorize()
        {
            var result = "Tôi là bracing man";

            return Ok(result);
        }

    }
}
