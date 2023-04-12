using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement1.Dto;
using OrderManagement1.Models;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CartsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;

        public CartsController(OrderManagement81363Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Carts
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetCart()
        {
            //GET data from database-Domain models
            var cart = await _context.Cart.Include("User").Include("Product").ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<GetCartDto>>(cart));
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CartDto>(cart));
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> PutCart([FromRoute] int id, [FromBody] CartDto cartDto)
        {
            var cart = mapper.Map<Cart>(cartDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> PostCart([FromBody] CartDto cartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = mapper.Map<Cart>(cartDto);
            await _context.Cart.AddAsync(cart);
            var cartDto1 = mapper.Map<CartDto>(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> DeleteCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<CartDto>(cart));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}