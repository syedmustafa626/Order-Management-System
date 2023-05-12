using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement1.Dto;
using OrderManagement1.Models;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(OrderManagement81363Context context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            
      
            _context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //GET data from database-Domain models
            var users = await _context.Users.ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<UsersDto>>(users));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UsersDto>(users));
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] UsersDto usersDto)
        {
            var users = mapper.Map<Users>(usersDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/Users
        //[HttpPost]
        //public async Task<IActionResult> PostUsers([FromBody] UsersDto usersDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var users = mapper.Map<Users>(usersDto);
        //    await _context.Users.AddAsync(users);
        //    var usersDto1 = mapper.Map<UsersDto>(users);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        //}




        [HttpPost]

        //[Route("Register")]

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
                    await _context.Users.AddAsync(user);


                    if (identityResult.Succeeded)
                    {
                        await _context.SaveChangesAsync();
                        return CreatedAtAction("GetUsers", new { id = user.UserId }, user);
                        //return Ok("User was Registered! Please Login..");
                    }
                }

            }
            return BadRequest("Something went Wrong!!!");
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<UsersDto>(users));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}