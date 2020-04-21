using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_XL_OMS.DTOs;
using API_XL_OMS.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_XL_OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
     
        private readonly IAuthenticateService _authService;
        public AuthenticationController(IAuthenticateService authService)
        {
            this._authService = authService;
        }
        [AllowAnonymous]
        [HttpPost, Route("requestToken")]
        public ActionResult RequestToken([FromBody] LoginRequestDTO request)
        {
           
            if (request.Username == "kyjj" && request.Password == "123456")
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Request");
                }
                string token;
                if (_authService.IsAuthenticated(request, out token))
                {
                    return Ok(token);
                }
            }

            return BadRequest("Invalid Request");

        }
    }
}