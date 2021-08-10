using DataService.Models.Entities;
using DataService.Models.Responses;
using DataService.Repositories;
using DataService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using relax_app.Extentions;
using relax_app.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relax_app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        public IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            AuthenticateResponse response = _userService
                .Authenticate(model.Username, model.Password, IpAddress());
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(new { message = "username or password is incorrect!" });
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] Models.Requests.RefreshToken refreshToken)
        {
            AuthenticateResponse response = _userService.RefreshToken(refreshToken.Token, IpAddress());
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] Models.Requests.RefreshToken refreshToken)
        {
            bool success = _userService.RevokeToken(refreshToken.Token, IpAddress());
            if (success)
            {
                return Ok(new { message = "Revoked! " });
            }
            return BadRequest(new { message = "Revoked failed!" });
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            User user = _userService.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        ///     Get my profile
        /// </summary>
        /// <returns></returns>
        [HttpGet("profiles")]
        public IActionResult GetMyProfile()
        {
            return Ok(_userService.FirstOrDefault(x => x.Id == this.GetUserId()));
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
