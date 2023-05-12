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
    [Authorize]
    public class CartItemsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;

        public CartItemsController(OrderManagement81363Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            //GET data from database-Domain models
            var cartItems = await _context.CartItems.Include("Cart").Include("Product").ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<GetCartItemsDto>>(cartItems));
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItems = await _context.CartItems.FindAsync(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CartItemsDto>(cartItems));
        }

        // PUT: api/CartItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItems([FromRoute] int id, [FromBody] CartItemsDto cartItemsDto)
        {
            var cartItems = mapper.Map<CartItems>(cartItemsDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItems.CartItemsId)
            {
                return BadRequest();
            }

            _context.Entry(cartItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemsExists(id))
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

        // POST: api/CartItems
        [HttpPost]
        public async Task<IActionResult> PostCartItems([FromBody] CartItemsDto cartItemsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItems = mapper.Map<CartItems>(cartItemsDto);
            await _context.CartItems.AddAsync(cartItems);
            var cartItemsDto1 = mapper.Map<CartItemsDto>(cartItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartItems", new { id = cartItems.CartItemsId }, cartItems);
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItems = await _context.CartItems.FindAsync(id);
            if (cartItems == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<CartItemsDto>(cartItems));
        }

        private bool CartItemsExists(int id)
        {
            return _context.CartItems.Any(e => e.CartItemsId == id);
        }
    }
}