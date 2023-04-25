using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagement1.Data;
using OrderManagement1.Dto;
using OrderManagement1.Models;
using OrderManagement1.Repositories;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly OrderManagement81363Context dbcontext;
        private readonly IMapper mapper;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, OrderManagement81363Context dbcontext,IMapper mapper)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        
        //public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        //{
        //    var identityUser = new IdentityUser
        //    {
        //        UserName = registerRequestDto.UserName,
        //        Email = registerRequestDto.UserName
        //    };

        //    var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

        //    if (identityResult.Succeeded)
        //    {
        //        //Add roles to this user
        //        if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
        //        {
        //            identityResult= await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

        //            if (identityResult.Succeeded)
        //            {
        //                return Ok("User was Registered! Please Login..");
        //            }
        //        }
                
        //    }
        //    return BadRequest("Something went Wrong!!!");
        //}

        public async Task<IActionResult> Register([FromBody] UsersDto userDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = userDto.UserEmail,
                Email = userDto.UserEmail
            };

            var identityResult = await userManager.CreateAsync(identityUser, userDto.UserPassword);
            var user = mapper.Map<Users>(userDto);

            if (identityResult.Succeeded)
            {
                //Add roles to this user
                if (userDto.Roles != null && userDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, userDto.Roles);
                    user.Roles = userDto.Roles[0];
                    await dbcontext.Users.AddAsync(user);


                    if (identityResult.Succeeded)
                    {
                        await dbcontext.SaveChangesAsync();
                        return Ok("User was Registered! Please Login..");
                    }
                }

            }
            return BadRequest("Something went Wrong!!!");
        }

        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
           var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //Get roles for the User
                    var roles = await userManager.GetRolesAsync(user);

                    if(roles != null)
                    {
                        //create token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                    
                }
            }
            return BadRequest("Username or Password Incorrect");
        }
    }
}