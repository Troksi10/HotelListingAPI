﻿using HotelListingAPI.Contracts;
using HotelListingAPI.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControler : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountControler(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        // POST : api/Account/register
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> Register([FromBody]ApiUserDto apiUserDto)
        {
            var errors = await _authManager.Register(apiUserDto);

            if(errors.Any()) 
            {
                foreach(var error in errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // POST : api/Account/login
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var authResponse = await _authManager.Login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
